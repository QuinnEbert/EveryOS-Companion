//
//  LoadAndSaveTools.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/11/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "LoadAndSaveTools.h"

@implementation LoadAndSaveTools

- (id)init
{
    self = [super init];
    if (self) {
        // Initialization code here.
    }
    
    return self;
}

- (NSString *) LoadTextFromFile:(NSString *)File {
    /* CREDIT: This code's based on code from the StackOverflow.com question thread from page: **
    ** <http://stackoverflow.com/questions/412562/execute-a-terminal-command-from-a-cocoa-app> */
    // Make sure File exists first:
    NSFileManager *fem = [NSFileManager defaultManager];
    if (![fem fileExistsAtPath:File])
        // Nope, bail out:
        return @"#!ERROR_NODATA!#";
    // Create NSFileHandle object:
    NSFileHandle *fp;
    // Prepare NSFileHandle to read from the passed in filename:
    fp = [NSFileHandle fileHandleForReadingAtPath:File];
    // Create NSData object:
    NSData *data;
    // Read all text file present within the file:
    data = [fp readDataToEndOfFile];
    // Close file handle:
    [fp closeFile];
    // Return the read text file data as a NSString value:
    return([[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding]);
}

- (void) SaveTextIntoFile:(NSString *)File SavingText:(NSString *)Text {
    /* CREDIT: This code's based on code from the StackOverflow.com question thread from page: **
    ** <http://stackoverflow.com/questions/412562/execute-a-terminal-command-from-a-cocoa-app> */
    /*// Create NSFileHandle object:
    NSFileHandle *fp;
    // Prepare NSFileHandle to read from the passed in filename:
    fp = [NSFileHandle fileHandleForWritingAtPath:File];
    // Create NSData object:*/
    NSData *data = [Text dataUsingEncoding:NSUTF8StringEncoding allowLossyConversion:FALSE];
    /*// Read all text file present within the file:
    [fp writeData:data];
    // Close file handle:
    [fp closeFile];*/
    NSFileManager *fwm = [NSFileManager defaultManager];
    [fwm createFileAtPath:File contents:data attributes:nil];
}

@end
