//
//  AppleSmartBatteryInfo.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 10/19/11.
//  Copyright (c) 2011 Beyond IT, LLC. All rights reserved.
//

#import "RunSystemCommand.h"

@class RunSystemCommand;

@interface AppleSmartBatteryInfo : NSObject {
    RunSystemCommand *SystemCommand;
}

- (NSString *) ioReg1Up;
- (BOOL) systemHasInstalledBattery;
- (NSString *) getTextForField:(NSString *)field;
- (NSString *) getTextualPercentRemains;
- (NSString *) getTextualCapacityStatus;
- (NSString *) getNumeralHealthPercentage;

@end
