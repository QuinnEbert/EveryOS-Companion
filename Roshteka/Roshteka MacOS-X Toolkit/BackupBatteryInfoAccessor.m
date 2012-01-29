//
//  BackupBatteryInfoAccessor.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/10/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "BackupBatteryInfoAccessor.h"

@implementation BackupBatteryInfoAccessor

@synthesize upsAccess;
@synthesize apcAccess;

- (id)init
{
    self = [super init];
    if (self) {
        SystemCommand = [[RunSystemCommand alloc] init];
        upsAccess = [[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/upsaccess"];
        apcAccess = [[[NSBundle mainBundle] bundlePath] stringByAppendingString:@"/Contents/Resources/apcaccess"];
    }
    return self;
}

/*
 Return the currently provided power (watts) on the APC device
 */
- (double)DoAccessGetActivePower {
    double a, b;
    a = [self DoAccessGetOutputPower];
    b = [self DoAccessGetLoadPercent];
    /* We get used watts by multiplying **
    ** capacity by decimal percent load **
    ** in use.                          */
    return (a*(b/100));
}

/*
 Return the currently provided power (watts) on the APC device as a NSString value (no decimal)
 */
- (NSString *)DoAccessGetActivePowerAsNumberString {
    return [NSString stringWithFormat:@"%i", (int) [self DoAccessGetActivePower]];
}

/*
 Return the currently provided power (watts) on the APC device as a NSString value (as decimal)
 */
- (NSString *)DoAccessGetActivePowerAsDoubleString {
    return [NSString stringWithFormat:@"%i", [self DoAccessGetActivePower]];
}

/*
 Return the maximum battery output load on the APC device
 */
- (double)DoAccessGetOutputPower {
    NSString *LoadPercentString = [self DoAccessGetValueForField:@"NOMPOWER"];
    return [[[LoadPercentString componentsSeparatedByString:@" "] objectAtIndex:0] doubleValue];
}

/*
 Return the maximum battery output load on the APC device as a NSString value (no decimal)
 */
- (NSString *)DoAccessGetOutputPowerAsNumberString {
    return [NSString stringWithFormat:@"%i", (int) [self DoAccessGetOutputPower]];
}

/*
 Return the load percent on the APC device
 */
- (double)DoAccessGetLoadPercent {
    NSString *LoadPercentString = [self DoAccessGetValueForField:@"LOADPCT"];
    return [[[LoadPercentString componentsSeparatedByString:@" "] objectAtIndex:0] doubleValue];
}

/*
 Return the remaining battery charge percent on the APC device
 */
- (NSString *)DoAccessGetBattPercent {
    NSString *txCharge = [self DoAccessGetValueForField:@"BCHARGE"];
    NSInteger inCharge = [[[txCharge componentsSeparatedByString:@"."] objectAtIndex:0] integerValue];
    NSString *bpCharge = [NSString stringWithFormat:@"%i", inCharge];
    return bpCharge;
}

/*
 Return TRUE if we're on mains power, FALSE otherwise...
 */
- (BOOL)AreUsingFacilityPower {
    NSString *pSource = [[[self DoAccessGetValueForField:@"STATUS"] componentsSeparatedByString:@" "] objectAtIndex:0];
    if ([pSource isEqualToString:@"ONLINE"])
        return TRUE;
    return FALSE;
}
/*
 Return the reverse of the AreUsingFacilityPower function...
 */
- (BOOL)AreUsingFailoverPower {
    if ([self AreUsingFacilityPower])
        return FALSE;
    return TRUE;
}

/*
 Return TRUE if we can determine max. and current load, FALSE otherwise...
 */
- (BOOL)SystemReallyHasBackup
{
    NSString *battUse = [self DoAccessGetActivePowerAsNumberString];
    NSString *battMax = [self DoAccessGetOutputPowerAsNumberString];
    if ([battUse isEqualToString:@"0"] && [battMax isEqualToString:@"0"])
        return FALSE;
    return TRUE;
}

/*
 Arbitrary returning of APCAccess row named "field" as an NSString
 */

- (NSString *)DoAccessGetValueForField:(NSString *)field
{
    NSArray *cafAccess = [[NSArray alloc] initWithObjects:apcAccess,field,nil];
    return [[SystemCommand doRunSystemCommand:upsAccess withArguments:cafAccess] stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]];
}

@end
