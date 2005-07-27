##
## Tao Makefile
##

DIRS = src examples

# Shell loops continue past errors without this.
EXIT_ON_ERROR := set -e;

all:
	$(MAKE) -C . build

build:
	@if [ ! -f config.mk ] ; then echo "No config.mk found; try make help."; exit 1; fi
	@$(EXIT_ON_ERROR) \
	for d in $(DIRS); do \
		$(MAKE) -C $$d $@; \
	done

##
## Per-platform configurations.
## Each platform needs a rule to copy its file
## to config.mk
##

mono-1.1::
	rm -f config.mk; cp config/mono-1-1.mk config.mk
	@echo "config.mk installed; re-run make."

net-1.1::
	rm -f config.mk; cp config/net-1-1.mk config.mk
	@echo "config.mk installed; re-run make."

help:
	@echo 'Use "make [targetname]" to configure the build'
	@echo 'valid targets:'
	@echo '  net-1.1        .NET 1.1'
	@echo '  mono-1.1       Mono 1.1'
	@echo ''
	@echo 'other variables:'
	@echo '  MONODIR        Location to find mono install, mcs will be used from $$MONODIR/bin'

clean:
	@$(EXIT_ON_ERROR) \
	for d in $(DIRS); do \
		$(MAKE) -C $$d $@; \
	done

docs:
	@$(EXIT_ON_ERROR) \
	for d in $(DIRS); do \
		$(MAKE) -C $$d $@; \
	done
