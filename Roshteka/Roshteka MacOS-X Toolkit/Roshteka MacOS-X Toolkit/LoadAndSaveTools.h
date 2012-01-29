//
//  LoadAndSaveTools.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/11/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//



@interface LoadAndSaveTools : NSObject

- (NSString *) LoadTextFromFile:(NSString *)File;
- (void) SaveTextIntoFile:(NSString *)File SavingText:(NSString *)Text;

@end
