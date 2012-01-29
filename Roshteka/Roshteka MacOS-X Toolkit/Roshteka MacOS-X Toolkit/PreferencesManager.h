//
//  PreferencesManager.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/7/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "LoadAndSaveTools.h"

@class LoadAndSaveTools;

@interface PreferencesManager : NSObject {
    NSString *PreferencesFile;
    NSMutableArray *PreferencePairs;
    LoadAndSaveTools *FSUtils;
}

@property (retain) NSString *PreferencesFile;
@property (retain) NSMutableArray *PreferencePairs;

- (void)ClearEverySetting;
- (void)ModSettingWithKey:(NSString *)key SetValue:(NSString *)value;
- (void)SetSettingWithKey:(NSString *)key SetValue:(NSString *)value;
- (NSString *)GetSettingWithKey:(NSString *)key;
- (void)RemoveSettingWithKey:(NSString *)key;
- (void)RemoveSettingAtIndex:(NSUInteger)idx;
- (BOOL)HasSettingWithKey:(NSString *)key;
- (void)LoadSavedSettings;
- (void)SaveInUseSettings;

@end
