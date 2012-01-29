//
//  RunSystemCommand.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/10/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

#import "RunSystemCommand.h"

@implementation RunSystemCommand

- (id)init
{
    self = [super init];
    if (self) {
        // Initialization code here.
    }
    return self;
}


- (NSString *)doRunSystemCommand:(NSString *)command withArguments:(NSArray *)arguments {
    /* CREDIT: This code is borrowed from the StackOverflow.com question thread from this URL:
     <http://stackoverflow.com/questions/412562/execute-a-terminal-command-from-a-cocoa-app> */
    // Create NSTask object:
    NSTask *task;
    // Initialize and allocate NSTask object:
    task = [[NSTask alloc] init];
    // Set the command to be executed:
    [task setLaunchPath:command];
    // Set the command arguments to be passed:
    [task setArguments:arguments];
    // Create NSPipe object:
    NSPipe *pipe;
    // Initialize and allocate NSPipe object:
    pipe = [NSPipe pipe];
    // Set up access to the standard output:
    [task setStandardOutput:pipe];
    // Create NSFileHandle object:
    NSFileHandle *file;
    // Prepare NSFileHandle to read from the standard output pipe:
    file = [pipe fileHandleForReading];
    // Start the command:
    [task launch];
    // Create NSData object:
    NSData *data;
    // Read all standard output received from the command:
    data = [file readDataToEndOfFile];
    // Return the received standard output data as a NSString value:
    return([[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding]);
}

@end
