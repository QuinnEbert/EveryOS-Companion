//
//  AppleSmartBatteryInfo.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 10/19/11.
//  Copyright (c) 2011 Beyond IT, LLC. All rights reserved.
//

#import "AppleSmartBatteryInfo.h"

@implementation AppleSmartBatteryInfo

- (NSString *) getTextualCapacityStatus
{
    if ([self systemHasInstalledBattery])
    {
        NSString *capaCur = [self getTextForField:@"CurrentCapacity"];
        NSString *capaMax = [self getTextForField:@"MaxCapacity"];
        return [NSString stringWithFormat:@"%@ milliamp hours remaining of %@ milliamp hours total", capaCur, capaMax];
    } else
    {
        return [NSString stringWithString:@"No system battery is installed here"];
    }
}

- (NSString *) getTextForField:(NSString *)field
{
    NSString *regData = [self ioReg1Up];
    NSArray *regLines = [regData componentsSeparatedByString:@"\n"];
    NSString *tmpLine = @"";
    NSString *rPrefix = [@"\"" stringByAppendingString:[field stringByAppendingString:@"\" = "]];
    NSString *returns = @"";
    for (id object in regLines) {
        tmpLine = [object stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]];
        if ([tmpLine hasPrefix:rPrefix])
        {
            returns = [[tmpLine componentsSeparatedByString:@" = "] objectAtIndex:1];
            return returns;
        }
    }
    // Total failure if we've reached here...
    return @"NOVALUE!";
}

- (NSString *) getTextualPercentRemains
{
    if ([self systemHasInstalledBattery]) {
        float capaCur = [[self getTextForField:@"CurrentCapacity"] floatValue];
        float capaMax = [[self getTextForField:@"MaxCapacity"] floatValue];
        float battPct = ((capaCur / capaMax) * 100);
        NSString *ret = [[[NSString stringWithFormat:@"%f", battPct] componentsSeparatedByString:@"."] objectAtIndex:0];
        return ret;
    }
    return @"NOVALUE!";
}

- (NSString *) getNumeralHealthPercentage
{
    float cFactory = [[[self getTextForField:@"DesignCapacity"] stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]] floatValue];
    float cCurrent = [[[self getTextForField:@"MaxCapacity"] stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]] floatValue];
    if (cFactory == 0 || cCurrent == 0)
        return @"0";
    float hPercent = ((cCurrent / cFactory) * 100);
    NSString *rVal = [[[[NSNumber numberWithFloat:hPercent] stringValue] componentsSeparatedByString:@"."] objectAtIndex:0];
    return rVal;
}

- (BOOL) systemHasInstalledBattery
{
    /* I am actually making the assumption that we should rely more on having
       present battery information than on the availability of the parameter
       BatteryIsInstalled.  Just guessing, but, this may change sometime. */
    if ([[self getTextForField:@"MaxCapacity"] isEqualToString:@"NOVALUE!"])
        return FALSE;
    return TRUE;
}

- (NSString *) ioReg1Up
{
    SystemCommand = [[RunSystemCommand alloc] init];
    NSString *ioRegCP = @"/usr/sbin/ioreg";
    NSString *ioRegCA = @"-r -w 0 -n AppleSmartBattery";
    NSArray *ioRegArg = [ioRegCA componentsSeparatedByString:@" "];
    NSString *regText = [SystemCommand doRunSystemCommand:ioRegCP withArguments: ioRegArg];
    NSArray *regLines = [regText componentsSeparatedByString:@"\n"];
    NSString *tmpLine = @"";
    NSString *returns = @"";
    for (id object in regLines) {
        tmpLine = [object stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]];
        if ([[tmpLine componentsSeparatedByString:@" = "] count] > 1)
            returns = [[returns stringByAppendingString:tmpLine] stringByAppendingString:@"\n"];
    }
    return returns;
}

@end
