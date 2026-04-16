#!/usr/bin/env python3
"""
Script to fix IronSource framework header warnings in Xcode project.
This script adds compiler flags to suppress the double-quoted include warnings.
"""

import re
import os

def fix_xcode_project():
    project_path = "/Users/otomo-k/Osanpo-Run/built program/Unity-iPhone.xcodeproj/project.pbxproj"
    
    if not os.path.exists(project_path):
        print(f"Error: Project file not found at {project_path}")
        return False
    
    # Read the project file
    with open(project_path, 'r') as f:
        content = f.read()
    
    # Find the build configurations and add the warning suppression flags
    warning_flags = [
        "-Wno-quoted-include-in-framework-header",
        "-Wno-deprecated-declarations"
    ]
    
    # Pattern to find OTHER_CFLAGS or OTHER_CPLUSPLUSFLAGS
    patterns = [
        (r'(OTHER_CFLAGS\s*=\s*\([^)]*)\);', r'\1 ' + ' '.join(f'"{flag}"' for flag in warning_flags) + ');'),
        (r'(OTHER_CPLUSPLUSFLAGS\s*=\s*\([^)]*)\);', r'\1 ' + ' '.join(f'"{flag}"' for flag in warning_flags) + ');'),
    ]
    
    modified = False
    for pattern, replacement in patterns:
        if re.search(pattern, content):
            content = re.sub(pattern, replacement, content)
            modified = True
    
    # If no existing OTHER_CFLAGS found, add them to build configurations
    if not modified:
        # Find build configuration sections and add the flags
        build_config_pattern = r'(buildSettings\s*=\s*\{[^}]*)(};)'
        
        def add_flags(match):
            build_settings = match.group(1)
            if 'OTHER_CFLAGS' not in build_settings:
                flags_line = f'\n\t\t\t\tOTHER_CFLAGS = ({" ".join(f\'"{flag}"\' for flag in warning_flags)},);'
                return build_settings + flags_line + '\n\t\t\t' + match.group(2)
            return match.group(0)
        
        content = re.sub(build_config_pattern, add_flags, content, flags=re.DOTALL)
        modified = True
    
    if modified:
        # Backup the original file
        backup_path = project_path + '.backup'
        with open(backup_path, 'w') as f:
            with open(project_path, 'r') as original:
                f.write(original.read())
        
        # Write the modified content
        with open(project_path, 'w') as f:
            f.write(content)
        
        print("✅ Successfully added compiler flags to suppress IronSource warnings")
        print(f"📁 Backup created at: {backup_path}")
        return True
    else:
        print("⚠️  No modifications needed or unable to modify project file")
        return False

if __name__ == "__main__":
    fix_xcode_project()