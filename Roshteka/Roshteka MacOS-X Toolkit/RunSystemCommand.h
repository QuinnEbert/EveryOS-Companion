//
//  RunSystemCommand.h
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 9/10/11.
//  Copyright 2011 Beyond IT, LLC. All rights reserved.
//

@interface RunSystemCommand : NSObject

- (NSString *)doRunSystemCommand:(NSString *)command withArguments:(NSArray *)arguments;

@end
