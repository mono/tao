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
        enumhash[line[0]] = string.atoi(line[2], 0)

# now output

for k in enumhash.keys():
    prefix = ""
    if GL_PREFIX or string.ascii_letters.find(k[0]) == -1:
        prefix = "GL_"

    print "    public const uint %s = 0x%08x;" % (prefix + k, enumhash[k])

