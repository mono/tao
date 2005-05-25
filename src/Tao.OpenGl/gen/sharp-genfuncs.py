#!/usr/bin/python

#
# sharp-genfuncs.py
#
# Author(s):
#   Vladimir Vukicevic <vladimir@pobox.com>
#
# Copyright (C) 2004 Vladimir Vukicevic <vladimir@pobox.com>
#
# This file is part of Tao; licensed under the MIT/X11 License
# as specified in the top-level License.txt file.
#

import sys, re, string

# handle parsing a single function from a .spec file
# line is the line indicating the start of the function

class SpecFunction:
  def __init__(self, fp, line):
    # first split the line into funcname and argnames
    self.fname = line[0 : line.find('(')]
    fargstr = line[line.find('(')+1 : line.find(')')]
    if fargstr == '':
      # no params
      self.fargs = []
    else:
      # this is weak, but we know that everything has ', ' in between
      self.fargs = fargstr.split(', ')
    self.fargtypes = {}
    self.extension = 0

    # keep reading and handing props until we get a blank line
    while 1:
      line = fp.readline()
      line.strip()
      if line == '':
        break
      props = line.split()
      if len(props) == 0:
        break
      if props[0] == 'return':
        self.rettype = props[1]
      elif props[0] == 'category':
        self.category = props[1]
      elif props[0] == 'version':
        self.version = props[1]
      elif props[0] == 'extension':
        self.extension = 1
      elif props[0] == 'param':
        # handle param args
        pname = props[1]
        self.fargtypes[pname] = {'type': props[2],
                                 'inout': props[3],
                                 'valtype': props[4]}
        if self.fargtypes[pname]['valtype'] == 'array':
          self.fargtypes[pname]['arraysize'] = props[5][1:-1]
      else:
        pass #ignore

  def arg(self, argname):
    return self.fargtypes[argname]

##
## printFunc
##

def printFunc(func):
  if len(func.fargs) == 0:
    print '    <function name="%s" rettype="%s" />' % (func.fname, func.rettype)
  else:
    print '    <function name="%s" rettype="%s">' % (func.fname, func.rettype)
    for arg in func.fargs:
      arginfo = func.fargtypes[arg]
      print '      <param name="%s" valtype="%s" type="%s" inout="%s" />' % (arg, arginfo['valtype'], arginfo['type'], arginfo['inout'])
    print '    </function>'
  
##
## printCore
##

def printCore(coreKey, coreData):
  print '  <coreset category="%s">' % coreKey
  for func in coreData:
    printFunc(func)
  print '  </coreset>\n'

##
## printExtension
##

def printExtension(extKey, extData):
  print '  <extset extension="%s">' % extKey
  for func in extData:
    printFunc(func)
  print '  </extset>\n'

##
## Main
##

def __main__():
  infp = sys.stdin
  
  ## This will hold a dict of extension and/or GL version names which
  ## will in turn point to a dict of that extension/version's functions
  categories = {}
  is_extension = {}
  
  while 1:
    line = infp.readline()
    if line == '':
      break

    if line[0] == '#':
      continue
    
    # if it starts with passthru, we ignore
    if line.startswith('passthru'):
      continue

    # no '('? continue.
    if line.find('(') == -1:
      continue

    # if it contains a (, then it's the start of a function
    func = SpecFunction(infp, line)
    if not categories.has_key(func.category):
      is_extension[func.category] = func.extension
      categories[func.category] = []

#    if func.extension != is_extension[func.category]:
#      sys.stderr.write("function '%s' in category '%s' differs in extension status from previous ('%d')!\n" % (func.fname, func.category, func.extension))
    
    categories[func.category].append(func)

  """ # MS did not update the opengl32.dll after version 1.2
  core_gl = ['1_1', 'VERSION_1_2', 'VERSION_1_3', 'VERSION_1_4', 'VERSION_1_5',
             'display-list', 'drawing', 'drawing-control', 'feedback', 'framebuf',
             'misc', 'modeling', 'pixel-op', 'pixel-rw', 'state-req', 'xform']
  """
  core_gl = ['1_1', 'VERSION_1_2', 'display-list', 'drawing', 'drawing-control', 
             'feedback', 'framebuf', 'misc', 'modeling', 'pixel-op', 'pixel-rw', 
             'state-req', 'xform']

  catkeys = categories.keys()
  
  # extensions that are badly specified in the spec files, or should
  # otherwise be skipped
  skip_gl = []
  

  # remove bad categories
  for v in skip_gl: catkeys.remove(v)
  # remove core categories, leaving only extensions
  for v in core_gl: catkeys.remove(v)
  catkeys.sort()

  print '<?xml version="1.0"?>'
  print '<glspec>'
  # first process core gl bits
  for k in core_gl:
    printCore(k, categories[k])
  # then process extensions
  for k in catkeys:
    printExtension(k, categories[k])
  print '</glspec>'

# go
__main__()
