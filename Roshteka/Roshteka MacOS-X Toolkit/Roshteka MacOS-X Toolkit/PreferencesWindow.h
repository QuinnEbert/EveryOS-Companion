//
//  PreferencesWindow.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/7/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "PreferencesManager.h"

@class PreferencesManager;

@interface PreferencesWindow : NSWindowController {
    NSButton *btnFinishOk;
    NSButton *btnFinishNo;
    IBOutlet NSImageView *imgRashtaka;
    IBOutlet NSButton *chkShowBackupBatteryInfo;
    IBOutlet NSPopUpButton *cmbBackupBatteryInfoHost;
    IBOutlet NSMenuItem *cmiUseHostBackupBatteryDaemon;
    IBOutlet NSMenuItem *cmiUsePackBackupBatteryDaemon;
    PreferencesManager *PreferencesManagerInstance;
}

@property (assign) IBOutlet NSButton *btnFinishOk;
@property (assign) IBOutlet NSButton *btnFinishNo;

@end
