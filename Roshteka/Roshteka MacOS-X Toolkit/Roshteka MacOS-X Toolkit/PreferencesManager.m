//
//  PreferencesManager.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/7/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "PreferencesManager.h"

@implementation PreferencesManager

@synthesize PreferencesFile;
@synthesize PreferencePairs;

- (id)init
{
    self = [super init];
    if (self) {
        // Initialize FSUtils for good measure
        FSUtils = [[LoadAndSaveTools alloc] init];
        // Set preference file disk location
        PreferencesFile = [NSHomeDirectory() stringByAppendingString:@"/Library/Preferences/Roshteka.dqPreferences"];
        // Load settings that were persisted to disk if possible
        [self LoadSavedSettings];
    }
    return self;
}

- (void)ClearEverySetting {
    [PreferencePairs dealloc];
    PreferencePairs = [[NSMutableArray alloc] init];
}

- (NSInteger)GetIndexOfSetting:(NSString *)key {
    NSUInteger count = [PreferencePairs count];
    NSString *compVal = [[@"\t" stringByAppendingString:key] stringByAppendingString:@"\n"];
   id tempVal;
    while (count--) {
        tempVal = [PreferencePairs objectAtIndex:count];
        if ([tempVal hasPrefix:compVal])
            return count;
    }
    return -1;
}

- (void)RemoveSettingWithKey:(NSString *)key {
    NSUInteger keyIndex = [self GetIndexOfSetting:key];
    [self RemoveSettingAtIndex:keyIndex];
}

- (void)RemoveSettingAtIndex:(NSUInteger)idx {
    [PreferencePairs removeObjectAtIndex:idx];
}

- (void)ModSettingWithKey:(NSString *)key SetValue:(NSString *)value {
    if ([key hasPrefix:@"\n"]) {
        NSLog(@"SetSettingWithKey: Keys cannot start with newline character!\n");
        return;
    }
    // Remove the existing key (if there is one)
    if ([self HasSettingWithKey:key])
        [self RemoveSettingWithKey:key];
    // Add the object into the array
    NSString *theData = [NSString stringWithFormat:@"\t%@\n%@", key, value];
    [PreferencePairs addObject:theData];
}

- (void)SetSettingWithKey:(NSString *)key SetValue:(NSString *)value {
    if ([self HasSettingWithKey:key]) {
        NSLog(@"SetSettingWithKey: The specified key was already present!\n");
        return;
    }
    if ([key hasPrefix:@"\n"]) {
        NSLog(@"SetSettingWithKey: Keys cannot start with newline character!\n");
        return;
    }
    [self ModSettingWithKey:key SetValue:value];
}

- (NSString *)GetSettingWithKey:(NSString *)key {
    NSString *compVal = [NSString stringWithFormat:@"\t%@", key];
    NSUInteger count = [PreferencePairs count];
    while (count--) {
        id tempVal = [PreferencePairs objectAtIndex:count];
        if ([tempVal hasPrefix:compVal])
            return [[tempVal componentsSeparatedByString:@"\n"] objectAtIndex:1];
    }
    return @"\t\n";
}

- (BOOL)HasSettingWithKey:(NSString *)key {
    if ([[self GetSettingWithKey:key] isEqualToString:@"\t\n"])
        return FALSE;
    return TRUE;
}

- (void)LoadSavedSettings
{
    // Ensure PreferencesFile always has the proper value:
    PreferencesFile = [NSHomeDirectory() stringByAppendingString:@"/Library/Preferences/Roshteka.dqPreferences"];
    // Load data from persistent storage:
    NSString *rawPrefFileData = [FSUtils LoadTextFromFile:PreferencesFile];
    // Bail out if no text read
    if ([rawPrefFileData isEqualToString:@"#!ERROR_NODATA!#"])
        return;
    // Ensure sane and clean settings pair array
    [self ClearEverySetting];
    // Set "status" setting key to indicate prefs not disk-loaded yet
    [self SetSettingWithKey:@"status" SetValue:@"FAILURE"];
    // Array out the data separating by tab + newline
    NSMutableArray *myPrefFileLines = [NSMutableArray arrayWithArray:[rawPrefFileData componentsSeparatedByString:@"\t\n"]];
    /*
     Loop through array, each line gets broken up into key and value by their in-class lead and seperator, and
     then loaded into the PreferencePairs using the class functions for that.
     */
    NSUInteger count = [myPrefFileLines count];
    NSString *tempStr;
    NSString *key;
    NSString *val;
    id tempVal;
    while (count--) {
        tempVal = [myPrefFileLines objectAtIndex:count];        
        tempStr = [tempVal stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]];
        key = [[tempStr componentsSeparatedByString:@"\n"] objectAtIndex:0];
        val = [[tempStr componentsSeparatedByString:@"\n"] objectAtIndex:1];
        [self ModSettingWithKey:key SetValue:val];
    }
    // Indicate with "status" setting key value disk-loading is finished
    [self ModSettingWithKey:@"status" SetValue:@"SUCCESS"];
}

- (void)SaveInUseSettings
{
    // Ensure PreferencesFile always has the proper value:
    PreferencesFile = [NSHomeDirectory() stringByAppendingString:@"/Library/Preferences/Roshteka.dqPreferences"];
    // String to hold the running preferences file data as we iterate through settings
    NSString *outData = @"";
    /*
     Loop through array, save each line as-stored in array verbatim, add trailing \t\n to each object.
     */
    NSUInteger count = [PreferencePairs count];
    NSString *tempStr;
    NSString *key;
    NSString *val;
    id tempVal;
    NSString *tempOut;
    while (count--) {
        tempVal = [[PreferencePairs objectAtIndex:count] stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]];
        tempStr = tempVal;
        key = [[tempStr componentsSeparatedByString:@"\n"] objectAtIndex:0];
        val = [[tempStr componentsSeparatedByString:@"\n"] objectAtIndex:1];
        tempOut = [NSString stringWithFormat:@"\t%@\n%@\t\n", key, val];
        outData = [outData stringByAppendingString:tempOut];
    }
    // Trim the whitespace (includes tabs and newlines) from the string (we don't want junk at the end)
    outData = [outData stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]];
    // Delete the existing file, before writing it out, if it does exist
    NSFileManager *fdm = [NSFileManager defaultManager];
    if ([fdm fileExistsAtPath:PreferencesFile])
        [fdm removeItemAtPath:PreferencesFile error:nil];
    // Now, write the preferences file to disk (include one leading tab removed while trimming whitespace)
    [FSUtils SaveTextIntoFile:PreferencesFile SavingText:[@"\t" stringByAppendingString:outData]];
}

- (void)dealloc
{
    [PreferencesFile release];
    [PreferencePairs release];
    [super dealloc];
}

@end
