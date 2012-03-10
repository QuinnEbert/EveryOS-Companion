//
//  Roshteka_MacOS_X_ToolkitAppDelegate.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/5/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "PreferencesManager.h"
#import "RunSystemCommand.h"
#import "BackupBatteryInfoAccessor.h"
#import "LoadAndSaveTools.h"
#import "AppleSmartBatteryInfo.h"
#import "SpeakOut.h"

@class PreferencesWindow;
@class ProBatteryInfoWindow;
@class PreferencesManager;
@class RunSystemCommand;
@class BackupBatteryInfoAccessor;
@class LoadAndSaveTools;
@class AppleSmartBatteryInfo;
@class SpeakOut;

@interface Roshteka_MacOS_X_ToolkitAppDelegate : NSObject <NSApplicationDelegate> {
    NSWindow *window;
    NSStatusItem *myStatusIcon;
    IBOutlet NSMenu *myStatusMenu;
    IBOutlet NSTextField *myStatusLine;
    IBOutlet NSTextField *lblPowerStatus;
    IBOutlet NSTextField *lblPwrLvlsHead;
    IBOutlet NSTextField *lblPowerLevels;
    IBOutlet NSTextField *lblBupBattHead;
    IBOutlet NSTextField *lblBupBattInfo;
    IBOutlet NSTextField *txtFullLogOutputView;
    IBOutlet NSMenuItem *mnuShowMainWindow;
    IBOutlet NSMenuItem *mnuletShowMainWindow;
    IBOutlet NSMenuItem *mnuletShowProBatteryInfo;
    PreferencesWindow *PreferencesWindowController;
    ProBatteryInfoWindow *ProBatteryInfoWindowController;
    PreferencesManager *PreferencesManagerInstance;
    RunSystemCommand *SystemCommand;
    AppleSmartBatteryInfo *BatteryInfo;
    BackupBatteryInfoAccessor *BackupBattery;
    LoadAndSaveTools *FSUtils;
    SpeakOut *myVoice;
    NSTimer *myTimer;
    NSString *oldPrefData;
    NSString *lastPwrFeed;
    NSString *lastBattPwr;
    bool lastUtilPwr;
    bool inThread;
}

// Assigned outlet properties
@property (assign) IBOutlet NSWindow *window;

// Retained value properties
@property (retain) NSString *oldPrefData;
@property (retain) NSString *lastPwrFeed;
@property (retain) NSString *lastBattPwr;
@property (retain) NSTimer *myTimer;

// Assigned value properties
@property (assign) bool lastUtilPwr;

- (BOOL)cepstral;
- (void)doPowerSourceInfoUpdateTasks;
- (void)doPreferencesDataRefreshTimer:(NSTimer *)source;
- (void)doPowerSourceInfoUpdateTimer:(NSTimer *)source;
- (void)logPrint:(NSString *)message;
- (void)runAlertWithTitle:(NSString *)title andWithMessage:message;
- (void)doPowerStatusChangeActions;
- (void)fileNotifications;
- (bool)getUtilityPowerStatus;
- (NSString *)getCurrentUnixDateAndTime;

@end
