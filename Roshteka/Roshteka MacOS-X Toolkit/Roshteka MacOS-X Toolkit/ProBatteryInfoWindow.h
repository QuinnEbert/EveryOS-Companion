//
//  ProBatteryInfoWindow.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 10/20/11.
//  Copyright (c) 2011 Beyond IT, LLC. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "AppleSmartBatteryInfo.h"

@class AppleSmartBatteryInfo;

@interface ProBatteryInfoWindow : NSWindowController {
    IBOutlet NSTextField *lblBatteryHealth;
    AppleSmartBatteryInfo *BatteryInfo;
}

- (void)updateProBatteryInfo;

@end
