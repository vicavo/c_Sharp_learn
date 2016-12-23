#!/bin/csh
#
# InCAM/Genesis/Geflex invoke script
# Dec 5, 2014	Lance Liao
# Works with DFM Quick Launcher

set session_config = $1
source $session_config

COM clipb_open_job,job=$MyJob,update_clipboard=view_job
COM open_job,job=$MyJob
COM open_entity,job=$MyJob,type=step,name=$MyStep,iconic=no
#COM units,type=inch

# Set display and affected layer
if("" != $MyLayer) then
	COM affected_layer,mode=all,affected=no
	COM affected_layer,name=$MyLayer,mode=single,affected=yes

	COM display_layer,name=$MyLayer,display=yes
	COM work_layer,name=$MyLayer
endif

# Open and run checklist
if("" != $MyChecklist) then
	COM chklist_open,chklist=$MyChecklist
	COM chklist_show,chklist=$MyChecklist

	if($?AutoRun && "yes" == $AutoRun) then
		COM chklist_run,chklist=$MyChecklist,nact=s,area=global
	endif
endif

exit 0


