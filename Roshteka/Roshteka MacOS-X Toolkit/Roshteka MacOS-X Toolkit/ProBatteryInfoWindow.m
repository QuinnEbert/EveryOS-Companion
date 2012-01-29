//
//  ProBatteryInfoWindow.m
//  Roshteka MacOS-X Toolkit
//
//  Created by David Ebert on 10/20/11.
//  Copyright (c) 2011 Beyond IT, LLC. All rights reserved.
//

#import "ProBatteryInfoWindow.h"

@implementation ProBatteryInfoWindow

- (id)init
{
    self = [super initWithWindowNibName:@"ProBatteryInfoWindow"];
    if (self)
    {
        /* Any code I put here loads at startup of the application **
        ** right when the first window loads up the Nib class file */
        
        //NSLog(@"Pro Battery Info Window Started...\n");
        
        // Initialise the Smart Battery Info accessor:
        BatteryInfo = [[AppleSmartBatteryInfo alloc] init];
    }
    return self;
}

- (void)updateProBatteryInfo {
    NSString *bHealth = [BatteryInfo getNumeralHealthPercentage];
    
    [lblBatteryHealth setStringValue:[NSString stringWithFormat:@"%@%% chargeable", bHealth]];
}

- (void)showWindow:(id)sender {
    /* Any code I put here loads whenever the window is opened **
    ** think of it like Cocoa's equivalent of VB's Form onLoad */
    
    //NSLog(@"Pro Battery Info Window Showing...\n");
    
    [self updateProBatteryInfo];
    
    // Bring the window into focus
    [[self window] makeKeyAndOrderFront:sender];
}


@end
