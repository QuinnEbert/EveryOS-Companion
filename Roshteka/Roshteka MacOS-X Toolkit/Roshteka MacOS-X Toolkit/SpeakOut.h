//
//  SpeakOut.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 11/11/11.
//  Copyright (c) 2011 Beyond IT, LLC. All rights reserved.
//

#include "RunSystemCommand.h"

@class RunSystemCommand;

@interface SpeakOut : NSObject {
    RunSystemCommand *Executor;
}

- (void)speak:(NSString *) text;

@end
