#!/usr/bin/perl -w
#
# Special thanks to snorp for telling me to use a batch file,
# and making me think of doing this processing.
#
# Usage: make | fixbat.pl > build.bat
#

$topdir = undef;
$topdirlen = 0;
$dirlevel = 0;

$striplen = 0;

@dirstack = ();

## some header stuff

print "\@echo off\r\n";
print "REM built from make using fixbat.pl, see other/fixbat.pl\r\n";
print "mkdir dist\r\n";
print "mkdir dist\\bin\r\n";
print "mkdir dist\\examples\r\n";

while (<>) {
  chop;

  if (/^make\[([0-9]*)\]: Entering directory `(.*)'$/) {
    local $targetdir = $2;

    #print "TARGET: $targetdir striplen: $striplen dirlevel $dirlevel top ", $dirstack[$#dirstack], "\n";

    if ($dirlevel == 0) {
      $topdir = $targetdir;
      $topdirlen = length($topdir);
      $striplen = length($topdir);
      push @dirstack, $topdir;
    } elsif ($targetdir eq $dirstack[$#dirstack]) {
      push @dirstack, ".";
    } else {
      local $cddir = substr($targetdir, $striplen + 1);
      $striplen = length($targetdir);

      if (length($targetdir) > $topdirlen) {
	local $printdir = substr($targetdir, $topdirlen + 1);
	print "echo $printdir\r\n";
      }

      print "chdir \"$cddir\"\r\n";
      push @dirstack, $targetdir;
    }

    $dirlevel++;
  } elsif (/^make\[([0-9]*)\]: Leaving directory `(.*)'$/) {
    local $thisdir = pop @dirstack;
    $dirlevel--;

    if ($thisdir ne "." && $dirlevel != 0) {
      print "chdir ..\r\n";
      if ($#dirstack >= 0) {
	$striplen = length($dirstack[$#dirstack]);
      }
    }
  } elsif (/^csc/ || /^ilasm/ || /^ildasm/ || /^..\/..\/dist\/bin\//) {
    local $foo = $_;
    $foo =~ s/([^ ])\//$1\\/g;
    print "$foo\r\n";
  } elsif (/^cp -f/) {
    local $foo = $_;
    $foo =~ s/([^ ])\//$1\\/g;
    $foo =~ s/^cp -f/copy \/y/;
    print $foo, "\r\n";
  }
}
