//
//  BackupBatteryInfoAccessor.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/10/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "RunSystemCommand.h"

@class RunSystemCommand;

@interface BackupBatteryInfoAccessor : NSObject {
    NSString *upsAccess;
    NSString *apcAccess;
    RunSystemCommand *SystemCommand;
}

@property (assign) NSString *upsAccess;
@property (assign) NSString *apcAccess;

- (double)DoAccessGetActivePower;
- (NSString *)DoAccessGetActivePowerAsNumberString;
- (double)DoAccessGetOutputPower;
- (NSString *)DoAccessGetOutputPowerAsNumberString;
- (double)DoAccessGetLoadPercent;
- (NSString *)DoAccessGetBattPercent;
- (NSString *)DoAccessGetValueForField:(NSString *)field;
- (BOOL)SystemReallyHasBackup;
- (BOOL)AreUsingFacilityPower;
- (BOOL)AreUsingFailoverPower;

@end
