//
//  SpeakOut.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 11/11/11.
//  Copyright (c) 2011 Beyond IT, LLC. All rights reserved.
//

#import "SpeakOut.h"

@implementation SpeakOut

- (void)speak:(NSString *) text {
    NSArray *SpeakArg = [NSArray arrayWithObjects:text,nil];
    Executor = [[RunSystemCommand alloc] init];
    [Executor doRunSystemCommand:@"/usr/bin/say" withArguments:SpeakArg];
}

@end