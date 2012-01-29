//
//  PreferencesWindow.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/7/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "PreferencesWindow.h"

@implementation PreferencesWindow
@synthesize btnFinishOk;
@synthesize btnFinishNo;

- (id)init
{
    self = [super initWithWindowNibName:@"PreferencesWindow"];
    if (self)
    {
        /* Any code I put here loads at startup of the application **
        ** right when the first window loads up the Nib class file */

        // Setup preferences manager...
        PreferencesManagerInstance = [[PreferencesManager alloc] init];
    }
    return self;
}

- (void)showWindow:(id)sender {
    /* Any code I put here loads whenever the window is opened **
    ** think of it like Cocoa's equivalent of VB's Form onLoad */

    // Alpha release (at least) preferences tab rashtaka's face nix border and add decor image
    [imgRashtaka setImageFrameStyle:NSImageFrameNone];
    [imgRashtaka setImage:[NSImage imageNamed:@"Roshteka_PreferencesWindow_AlphaRelease_PreferencesTab.jpg"]];
    
    /* Following two now set in Interface Builder */
    // Set OK button as default
    //[btnFinishOk setKeyEquivalent:@"\r"];
    // Set Cancel button bind to ESC key
    //[btnFinishNo setKeyEquivalent:@"\e"];
    
    /*
     BINDINGS OF CONTROLS TO PREFERENCES
     */
    if ([PreferencesManagerInstance HasSettingWithKey:@"upsaccess_enable"]) {
        if ([[[PreferencesManagerInstance GetSettingWithKey:@"upsaccess_enable"] lowercaseString] isEqualToString:@"yes"]) {
            [chkShowBackupBatteryInfo setState:NSOnState];
            [cmbBackupBatteryInfoHost setEnabled:TRUE];
        } else {
            [chkShowBackupBatteryInfo setState:NSOffState];
            [cmbBackupBatteryInfoHost setEnabled:FALSE];
        }
    }
    if ([PreferencesManagerInstance HasSettingWithKey:@"upsaccess_source"]) {
        if ([[[PreferencesManagerInstance GetSettingWithKey:@"upsaccess_source"] lowercaseString] isEqualToString:@"pack"]) {
            [cmiUseHostBackupBatteryDaemon setState:NSOffState];
            [cmiUsePackBackupBatteryDaemon setState:NSOnState];
            [cmbBackupBatteryInfoHost setTitle:[cmiUsePackBackupBatteryDaemon title]];
        } else {
            [cmiUseHostBackupBatteryDaemon setState:NSOnState];
            [cmiUsePackBackupBatteryDaemon setState:NSOffState];
            [cmbBackupBatteryInfoHost setTitle:[cmiUseHostBackupBatteryDaemon title]];
        }
    }

    // Bring the window into focus
    [[self window] makeKeyAndOrderFront:sender];
}

/*
 Handle check/uncheck of the "UPS Info Enabled" checkbox
 */
- (IBAction)chkShowBackupBatteryInfo_onClick:(id)sender {
    if ([chkShowBackupBatteryInfo state] == NSOnState) {
        // Enable the UPS info source pop-up menu
        [cmbBackupBatteryInfoHost setEnabled:TRUE];
    } else {
        // Disable the UPS info source pop-up menu
        [cmbBackupBatteryInfoHost setEnabled:FALSE];
    }
}

- (IBAction)doViewWookieeArtDisc:(id)sender {
    // Not using SystemCommand because we don't need the output and it's only a one-shot thing
    system("/usr/bin/open 'http://furplanet.com/shop/item.aspx?itemid=85'");
}

- (IBAction)doExitWithButtonOk:(id)sender {
    // Commit visual settings change into preference set
    [PreferencesManagerInstance ClearEverySetting]; // clear anything there
    if ([chkShowBackupBatteryInfo state] == NSOnState) { // UPS Info Enable/Disable
        [PreferencesManagerInstance ModSettingWithKey:@"upsaccess_enable" SetValue:@"YES"];
    } else {
        [PreferencesManagerInstance ModSettingWithKey:@"upsaccess_enable" SetValue:@"NO"];
    }
    if ([cmiUsePackBackupBatteryDaemon state] == NSOnState) { // UPS Info Source
        [PreferencesManagerInstance ModSettingWithKey:@"upsaccess_source" SetValue:@"PACK"];
    } else {
        [PreferencesManagerInstance ModSettingWithKey:@"upsaccess_source" SetValue:@"HOST"];
    }
    // And, dump the settings to disk
    [PreferencesManagerInstance SaveInUseSettings];
    
    // Close the window
    [[self window] close];
    // Deallocate
    [self dealloc];
}

- (IBAction)doExitWithButtonNo:(id)sender {
    // Close the window
    [[self window] close];
    // Deallocate
    [self dealloc];
}

- (void)dealloc {
    [[self window] release];
    [self release];
}

@end
