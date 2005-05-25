#!/usr/bin/python

#
# sharp-genenums.py
#
# Author(s):
#   Vladimir Vukicevic <vladimir@pobox.com>
#
# Copyright (C) 2004 Vladimir Vukicevic <vladimir@pobox.com>
#
# This file is part of Tao; licensed under the MIT/X11 License
# as specified in the top-level License.txt file.
#

GL_PREFIX = 1

import sys, re, string

enumhash = {}

# read
while 1:
    line = sys.stdin.readline()
    if line == '':
        break
    if line[0] != '\t':
        continue
    
    line = string.strip(line)
    line = string.split(line)

    if line[1] == '=':
        enumname = line[0]
        enumtarget = line[2]
        enumval = 0
        try:
            enumval = string.atoi(enumtarget, 0)
        except:
            enumval = enumtarget
        enumhash[enumname] = enumval

# now output

for k in enumhash.keys():
    prefix = ""
    if GL_PREFIX or string.ascii_letters.find(k[0]) == -1:
        prefix = "GL_"

    val = enumhash[k]
    while type(val) == str:
        if val[0:3] == "GL_":
            val = val[3:]
        val = enumhash[val]

    if (val < 0 or val > 0x7fffffff):
        print "    public const int %s = unchecked((int) 0x%08x);" % (prefix + k, val)
    else:
        print "    public const int %s = 0x%08x;" % (prefix + k, val)

