//
//  Roshteka_MacOS_X_ToolkitAppDelegate.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/5/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "Roshteka_MacOS_X_ToolkitAppDelegate.h"
#import "PreferencesWindow.h"
#import "ProBatteryInfoWindow.h"

@implementation Roshteka_MacOS_X_ToolkitAppDelegate

/* Synthesis of Classes and Accessors */
@synthesize window;

/* Synthesis of Value Store Variables */
@synthesize oldPrefData;
@synthesize lastBattPwr;
@synthesize lastPwrFeed;
@synthesize lastUtilPwr;
@synthesize myTimer;

- (void) receiveSleepNote: (NSNotification*) note
{
    [self logPrint:[NSString stringWithFormat:@"receiveSleepNote: %@", [note name]]];
    
    // Halt the refresh timer...
    [myTimer invalidate];
}

- (void) receiveWakeNote: (NSNotification*) note
{
    [self logPrint:[NSString stringWithFormat:@"receiveSleepNote: %@", [note name]]];

    // Make the refresh timer...
    myTimer = [NSTimer scheduledTimerWithTimeInterval:20.0 target:self selector:@selector(doPowerSourceInfoUpdateTimer:) userInfo:nil repeats:YES];
}

- (void) fileNotifications
{
    [self logPrint:@"Ask for system notifications..."];
    //These notifications are filed on NSWorkspace's notification center, not the default 
    // notification center. You will not receive sleep/wake notifications if you file 
    //with the default notification center.
    [[[NSWorkspace sharedWorkspace] notificationCenter] addObserver: self 
                                                           selector: @selector(receiveSleepNote:) 
                                                               name: NSWorkspaceWillSleepNotification object: NULL];
    
    [[[NSWorkspace sharedWorkspace] notificationCenter] addObserver: self 
                                                           selector: @selector(receiveWakeNote:) 
                                                               name: NSWorkspaceDidWakeNotification object: NULL];
    [self logPrint:@"Asked for system notifications!"];
}

//FIXME: This could probably be implemented in one of the libraries, but, for now here is good enough...
- (bool)getUtilityPowerStatus
{
    if ([BackupBattery SystemReallyHasBackup])
        return [BackupBattery AreUsingFacilityPower];
    return TRUE;
}

- (NSString *)getCurrentUnixDateAndTime
{
    // Get the current in use system timezone offset:
    NSArray *dateArgs = [NSArray arrayWithObjects:@"+%Y-%m-%d %H:%M:%S %z", nil];
    NSString *returns = [[SystemCommand doRunSystemCommand:@"/bin/date" withArguments:dateArgs] stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]];
    return returns;
}

- (void)applicationDidFinishLaunching:(NSNotification *)aNotification
{
    
    // Not threading when we first launch, eh?
    inThread = FALSE;
    
    // Give session variables good default values...
    lastBattPwr = @"NO_PROBE";
    lastUtilPwr = true;
    
    // Initialize FSUtils for good measure
    FSUtils = [[LoadAndSaveTools alloc] init];
    
    // Load an initial preferences data set to keep comparison timer happy
    NSString *PreferencesFile = [NSHomeDirectory() stringByAppendingString:@"/Library/Preferences/Roshteka.dqPreferences"];
    oldPrefData = [FSUtils LoadTextFromFile:PreferencesFile];
    
    // Prepare to make sure we have the files we need for support of the backend things
    NSFileManager *manager = [NSFileManager defaultManager];
    BOOL gotApplePmSet; gotApplePmSet = FALSE;
    BOOL gotWeatherCli; gotWeatherCli = FALSE;
    BOOL gotWeatherPys; gotWeatherPys = FALSE;
    BOOL gotWeatherCfg; gotWeatherCfg = FALSE;
    BOOL gotInfoCliAPC; gotInfoCliAPC = FALSE;
    BOOL gotInfoCliUPS; gotInfoCliUPS = FALSE;
    // ...constant path to the Apple pmset utility...
    NSString *pmsUtil = @"/usr/bin/pmset";
    // ...and now look for the items...
    gotApplePmSet = [manager fileExistsAtPath:pmsUtil];
    gotWeatherCli = [manager fileExistsAtPath:[[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/weather"]];
    gotWeatherPys = [manager fileExistsAtPath:[[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/weather.py"]];
    gotWeatherCfg = [manager fileExistsAtPath:[[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/weatherrc"]];
    gotInfoCliAPC = [manager fileExistsAtPath:[[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/apcaccess"]];
    gotInfoCliUPS = [manager fileExistsAtPath:[[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/upsaccess"]];
    
    // Setup system command runner library
    SystemCommand = [[RunSystemCommand alloc] init];
    
    // Setup message speak library
    myVoice = [[SpeakOut alloc] init];
    
    // For gathering the initial power source:
    NSArray *cmdArgs = [NSArray arrayWithObjects:@"-g",@"ps",nil];
    NSString *pwrInfo = [[[SystemCommand doRunSystemCommand:pmsUtil withArguments:cmdArgs] componentsSeparatedByString:@"'"] objectAtIndex:1];
    
    // Apple smart battery info accessor setup
    BatteryInfo = [[AppleSmartBatteryInfo alloc] init];
    // TESTING ONLY:
    //[BatteryInfo getTextForField:@"CurrentCapacity"];
    // Give an initial battery percentage value to lastBattPwr
    lastBattPwr = [BatteryInfo getTextualPercentRemains];
    //FIXME: Duplicate code below...
    // Give an initial power source value to lastPwrFeed
    if ([[pwrInfo lowercaseString] isEqualToString:@"ac power"])
    {
        lastPwrFeed = @"AC";
    } else
    {
        lastPwrFeed = @"DC";
    }
    
    // Setup preferences manager
    PreferencesManagerInstance = [[PreferencesManager alloc] init];
    
    // Setup backup battery info accessor
    BackupBattery = [[BackupBatteryInfoAccessor alloc] init];

    // Now set an initial UPS source availability status
    lastUtilPwr = [self getUtilityPowerStatus];
    
    // Setup the menulet and its clickable status menu
    myStatusIcon = [[[NSStatusBar systemStatusBar] statusItemWithLength:NSSquareStatusItemLength] retain];
    [myStatusIcon setImage:[NSImage imageNamed:@"menulet.tiff"]];
    [myStatusIcon setHighlightMode:YES];
    [myStatusIcon setToolTip:@"Roshteka MacOS-X Toolkit"];
    [myStatusIcon setMenu:myStatusMenu];
    
    // Set the dark gray text color for the main window's status bar
    [myStatusLine setTextColor:[NSColor darkGrayColor]];

    // Report the status of looking for needed files in the main app window's status bar
    if ( ! gotApplePmSet ) {
        // ...Didn't find the system-wide Apple pmset utility...
        [myStatusLine setStringValue:@"Problem: \"pmset\" MacOS utility not found!"];
    } else if ( ! gotWeatherPys ) {
        // ...Didn't find the Python library in the bundle...
        [myStatusLine setStringValue:@"Problem: weather library backend not found!"];        
    } else if ( ! gotInfoCliAPC ) {
        // ...Didn't find the bundled apcaccess...
        [myStatusLine setStringValue:@"Problem: UPS info backend APC support binary not found!"];
    } else if ( ! gotInfoCliUPS ) {
        // ...Didn't find the bundled upsaccess...
        [myStatusLine setStringValue:@"Problem: UPS info backend binary not found!"];
    } else if ( ! gotWeatherCli ) {
        // ...Didn't find the CLI in the bundle...
        [myStatusLine setStringValue:@"Problem: weather command backend not found!"];
    } else if ( ! gotWeatherCfg ) {
        // ...Didn't find the CLI's config (rc) file in the bundle...
        [myStatusLine setStringValue:@"Problem: weather command configs not found!"];
    } else {
        // ...Good to go here...
        [myStatusLine setStringValue:@"No problems currently to report!"];
    }
    
    // Make sure the main window's always visible at startup
    [window setIsVisible:TRUE];
    
    /* If we have the "pmset" utility get initial power status info
       otherwise display additional info alerting to absent utility */
    if ( gotApplePmSet ) {
        // ...Run one update...
        [self doPowerSourceInfoUpdateTasks];
        // ...And, start the timer, to refresh power status info regularly...
        myTimer = [NSTimer scheduledTimerWithTimeInterval:20.0 target:self selector:@selector(doPowerSourceInfoUpdateTimer:) userInfo:nil repeats:YES];
    } else {
        // ...Give them an error message in the status label...
        [lblPowerStatus setStringValue:@"Unable to retrieve power status!"];
    }
    
    // Setup a timer to check preferences every minute
    [NSTimer scheduledTimerWithTimeInterval:60.0 target:self selector:@selector(doPreferencesDataRefreshTimer:) userInfo:nil repeats:YES];
        
    // Let them know startup has now been completed
    [self logPrint:@"Application is ready!"];
    //[self logPrint:[lastBattPwr stringByAppendingString:@" percent battery power remains here."]];
    //[myVoice speak:@"Hello, my name is Sangeeta, I'm an Indian English voice."];
    //[myVoice speak:[lastBattPwr stringByAppendingString:@" percent battery power remains here."]];
    
    // Debug info => speech system used
    if ([self cepstral]) {
        [self logPrint:@"Will speak using Cepstral!"];
    } else {
        [self logPrint:@"Will speak using MacinTalk!"];
    }
    
    // Setup system event notifications
    [self fileNotifications];
    
}

- (BOOL)cepstral {
    NSFileManager *NSFM = [NSFileManager defaultManager];
    return [NSFM fileExistsAtPath:@"/usr/bin/swift"];
}

- (void)doPowerStatusChangeActions {
    
    // Are we already running?
    //if (inThread) {
    //    [self logPrint:@"Lock hit in doPowerStatusChangeActions"];
    //    return;
    //}
    
    // Try to lock out...
    //inThread = true;
    
    // Give an initial battery percentage value to lastBattPwr:
    NSString *currBattPwr = [BatteryInfo getTextualPercentRemains];
    NSString *currPwrFeed = [[NSString alloc] init];
    bool currUtilPwr = [self getUtilityPowerStatus];
    //FIXME: Duplicate code below...
    NSString *pmsUtil = @"/usr/bin/pmset";
    NSArray *cmdArgs = [NSArray arrayWithObjects:@"-g",@"ps",nil];
    NSString *pwrInfo = [[[SystemCommand doRunSystemCommand:pmsUtil withArguments:cmdArgs] componentsSeparatedByString:@"'"] objectAtIndex:1];
    if ([[pwrInfo lowercaseString] isEqualToString:@"ac power"])
    {
        currPwrFeed = @"AC";
    } else
    {
        currPwrFeed = @"DC";
    }
    
    // Compare and announce source status as needed:
    if ([currPwrFeed isEqualToString:lastPwrFeed] == FALSE)
    {
        if ([currPwrFeed isEqualToString:@"DC"])
        {
            [myVoice speak:@"The system is now running on battery power."];
        } else
        {
            [myVoice speak:@"The system is now running on adapter power."];
        }
    }
    
    if ([BatteryInfo systemHasInstalledBattery])
    {
        // Compare and announce level status as needed:
        if ([currBattPwr isEqualToString:lastBattPwr] == FALSE)
        {
            if ([currBattPwr intValue] < [lastBattPwr intValue])
            {
                //FIXME: Duplicated due to irrelevant perceived logic flaw.
                if ([currBattPwr hasSuffix:@"0"])
                {   
                    [myVoice speak:[NSString stringWithFormat:@"Battery has run down to %@ percent!", currBattPwr]];
                }
            } else
            {
                //FIXME: Duplicated due to irrelevant perceived logic flaw.
                if ([currBattPwr hasSuffix:@"0"])
                {
                    if ([currBattPwr isEqualToString:@"100"] == FALSE)
                    {
                        [myVoice speak:[NSString stringWithFormat:@"Battery has recharged up to %@ percent!", currBattPwr]];
                    } else
                    {
                        [myVoice speak:[NSString stringWithFormat:@"Battery has reached a full charge!", currBattPwr]];
                    }
                }
            }
        }
    } else
    {
        if (currUtilPwr != lastUtilPwr)
        {
            if (! currUtilPwr)
            {
                [self logPrint:@"UPS ALERT: power failure, running on batteries!"];
                [myVoice speak:@"The system just started running off UPS power!"];
            } else
            {
                [self logPrint:@"UPS ALERT: power has returned!"];
                [myVoice speak:@"The system has resumed running on mains power!"];
            }
        }
    }
    
    // Update the stored statuses:
    lastPwrFeed = currPwrFeed;
    lastBattPwr = currBattPwr;
    lastUtilPwr = currUtilPwr;
    
    [lastPwrFeed retain];
    [lastBattPwr retain];
    
    // TESTING ONLY:
    //[myStatusLine setStringValue:[NSString stringWithFormat:@"Battery charge: %@ percent.", currBattPwr]];
    
    // Try to end lock...
    //inThread = false;
    
    // Make sure we will be retained...
    [myTimer retain];
    
}

- (void)doPowerSourceInfoUpdateTasks {
    // ...constant path to the Apple pmset utility...
    NSString *pmsUtil = @"/usr/bin/pmset";
    // ...Refresh and update the info...
    NSArray *cmdArgs = [NSArray arrayWithObjects:@"-g",@"ps",nil];
    // ...send the command...
    NSString *pwrInfo = [[[SystemCommand doRunSystemCommand:pmsUtil withArguments:cmdArgs] componentsSeparatedByString:@"'"] objectAtIndex:1];
    // ...hold the text for current power source status...
    NSString *results = @"";
    // ...smartly form a string for power source status...
    if ([BatteryInfo systemHasInstalledBattery])
    {
        if ([[pwrInfo lowercaseString] isEqualToString:@"ac power"])
        {
            results = @"Mains wall outlet (AC)";
        } else
        {
            results = @"Main battery pack (DC)";
        }
    } else
    {
        if ([BackupBattery SystemReallyHasBackup] && [BackupBattery AreUsingFailoverPower])
        {
            results = @"UPS battery packs (DC)";
        } else
        {
            results = @"Mains wall outlet (AC)";
        }
    }
    // ...update status label...
    [lblPowerStatus setStringValue:[results stringByTrimmingCharactersInSet:[NSCharacterSet newlineCharacterSet]]];
    // FIXME: Implementation?
    [lblPwrLvlsHead setStringValue:@"Battery Status:"];
    [lblPowerLevels setStringValue:[BatteryInfo getTextualCapacityStatus]];
    /*
     UPS INFO STUFF
     */
    // Hide labels if UPS disabled, otherwise update them
    if ([[[PreferencesManagerInstance GetSettingWithKey:@"upsaccess_enable"] lowercaseString] isEqualToString:@"no"]) {
        [lblBupBattHead setStringValue:@""];
        [lblBupBattInfo setStringValue:@""];
    } else {
        [lblBupBattHead setStringValue:@"UPS Status"];
        NSString *battTxt;
        NSString *battUse = [BackupBattery DoAccessGetActivePowerAsNumberString];
        NSString *battMax = [BackupBattery DoAccessGetOutputPowerAsNumberString];
        NSString *battPct = [BackupBattery DoAccessGetBattPercent];
        if ([BackupBattery SystemReallyHasBackup] == FALSE)
        {
            battTxt = [NSString stringWithString:@"No backup battery is installed here"];
        } else
        {
            battTxt = [NSString stringWithFormat:@"%@ watts used of %@ watts available (%@%% charge)", battUse, battMax, battPct];            
        }
        [lblBupBattInfo setStringValue:battTxt];
    }
    // Announce any interesting power source or level status changes
    [self doPowerStatusChangeActions];
}

- (void)doPreferencesDataRefreshTimer:(NSTimer *)source {
    //[self logPrint:@"Preferences are refreshing!"];
    NSString *PreferencesFile = [NSHomeDirectory() stringByAppendingString:@"/Library/Preferences/Roshteka.dqPreferences"];
    NSString *newPrefData = [FSUtils LoadTextFromFile:PreferencesFile];
    if ([newPrefData isEqualToString:oldPrefData]==NO) {
        [PreferencesManagerInstance LoadSavedSettings];
    }
    oldPrefData = newPrefData;
}

- (void)doPowerSourceInfoUpdateTimer:(NSTimer *)source {
    [self doPowerSourceInfoUpdateTasks];
}

- (IBAction)doOpenPreferencesWindow:(id)sender {
    // Start up new window controller:
    PreferencesWindowController = [[PreferencesWindow alloc] init];
    // Force the window into visibility:
    if ([[PreferencesWindowController window] isVisible]==FALSE)
        [PreferencesWindowController showWindow:self];
}

- (IBAction)doEndAppViaMenulet:(id)sender {
    // Shut down the application when the status menu's "quit" item gets clicked
    exit(EXIT_SUCCESS);
}

/*
 Handle "Hide" Main Window Button Click Events
 */
- (IBAction)btnHideMainWindow_onClick:(id)sender {
    // Hide the app's main window...
    [window setIsVisible:FALSE];
    // ...and, uncheck the menu item...
    [mnuShowMainWindow setState:NSOffState];
    [mnuletShowMainWindow setState:NSOffState];
}

/*
 Handle "Show Main Window" > "View" Menu Item Clicks
 */
- (IBAction)mnuShowMainWindow_onClick:(id)sender {
    if ([mnuShowMainWindow state] == NSOnState) {
        // Menu item's checked, hide window...
        [window setIsVisible:FALSE];
        // ...and, uncheck the menu item...
        [mnuShowMainWindow setState:NSOffState];
        [mnuletShowMainWindow setState:NSOffState];
    } else {
        // Menu item's unchecked, show window...
        [window setIsVisible:TRUE];
        // ...and, check the menu item...
        [mnuShowMainWindow setState:NSOnState];
        [mnuletShowMainWindow setState:NSOnState];
    }
}

/*
 Handle Menulet > "Show Main Window" Menu Item Clicks
 */
- (IBAction)mnuletShowMainWindow_onClick:(id)sender {
    if ([mnuletShowMainWindow state] == NSOnState) {
        // Menu item's checked, hide window...
        [window setIsVisible:FALSE];
        // ...and, uncheck the menu item...
        [mnuShowMainWindow setState:NSOffState];
        [mnuletShowMainWindow setState:NSOffState];
    } else {
        // Menu item's unchecked, show window...
        [window setIsVisible:TRUE];
        // ...and, check the menu item...
        [mnuShowMainWindow setState:NSOnState];
        [mnuletShowMainWindow setState:NSOnState];
    }
}

/* Show/Hide Pro Battery Info via Menulet */
- (IBAction)mnuletShowProBatteryInfo_onClick:(id)sender
{
    // Only show if main battery can be found:
    if ([BatteryInfo systemHasInstalledBattery])
    {
        // Start up new window controller:
        ProBatteryInfoWindowController = [[ProBatteryInfoWindow alloc] init];
        // Force the window into visibility:
        if ([[ProBatteryInfoWindowController window] isVisible]==FALSE)
            [ProBatteryInfoWindowController showWindow:self];
    } else
    {
        [self runAlertWithTitle:@"No system battery detected!" andWithMessage:@"Your system is either not a portable Macintosh or your portable Macintosh system's battery is currently ejected.  Professional battery information cannot be accessed until an Apple Smart Battery is inserted into the system so its specifics can be enumerated."];
    }
}

/*
 Run NS Alert Dialogue with message, OK button only
 */
- (void)runAlertWithTitle:(NSString *)title andWithMessage:message {
    NSRunAlertPanel(title,message,@"OK",@"",@"");
}

/*
 Add message (with newline appended) to the log view
 */
- (void)logPrint:(NSString *)message {
    NSString *logText = [txtFullLogOutputView stringValue];
    logText = [logText stringByAppendingString:[[[self getCurrentUnixDateAndTime] componentsSeparatedByString:@" -"] objectAtIndex:0]];
    logText = [logText stringByAppendingString:@": "];
    logText = [logText stringByAppendingString:[message stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]]];
    logText = [logText stringByAppendingString:@"\n"];
    [txtFullLogOutputView setStringValue:logText];
}

@end
