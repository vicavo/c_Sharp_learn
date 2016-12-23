#!/bin/csh
#
# InCAM invoke script to open autotest results layers and compare
# July 5, 2016	Lance Liao
# Works with DFM Quick Launcher

set at_config = $1
source $at_config

# Testing at_config file content
#set MyJob=sme
#set MyStep=edit
#set MyChecklist=slr
#set MyLayer=x
#set MyVer="dev"
#set MyVerRef="231dev"

# If these two parameters are not specified("run_params" not found)
# we try to set default value
if (! $?MyVer) then 
	set MyVer="new"
endif

if (! $?MyVerRef) then 
	set MyVerRef="ref"
endif

# Create the layer names to be compared
set ThisLayer="$MyLayer.$MyVer"
set RefLayer="$MyLayer.$MyVerRef"

if ( $?Analysis ) then
	set RefLayer="ms_1_${MyLayer}_ref"
	set ThisLayer="ms_1_${MyLayer}_cur"
endif

# The result map layer
set MapLayer="map_$ThisLayer"

set MyResolution=200
if ($?COMPARE_SMALL_BOX) then
   set MyResolution=50
endif

# Open job and step
COM clipb_open_job,job=$MyJob,update_clipboard=view_job
COM open_job,job=$MyJob
COM open_entity,job=$MyJob,type=step,name=$MyStep,iconic=no
COM check_inout,job=$MyJob,mode=out,ent_type=job
COM units,type=inch

# Check if map layer already exists
# yes: open the map layer to check the result
# no: run comparing and re-create the map layer
set InfoFile="$INCAM_TMP/info-incam_checklayer_.9999"
COM info, out_file=$InfoFile, write_mode=append,args=  -t layer -e $MyJob/$MyStep/$MapLayer -m script -d EXISTS
source $InfoFile
rm -f $InfoFile

# We have to check out and close the job before we check it out for changes
# or else we can not save our changes to the job or check int the job
if ($gEXISTS != "yes" || $?ForceReCompare) then
	COM close_job,job=$MyJob

	COM clipb_open_job,job=$MyJob,update_clipboard=view_job
	COM open_job,job=$MyJob
	COM open_entity,job=$MyJob,type=step,name=$MyStep,iconic=no
	COM check_inout,job=$MyJob,mode=out,ent_type=job
	COM units,type=inch
endif

# Display the two layers to be compared
COM affected_layer,mode=all,affected=no
COM display_layer,name=$ThisLayer,display=yes
COM work_layer,name=$ThisLayer
COM affected_layer,name=$ThisLayer,mode=single,affected=yes
COM display_layer,name=$RefLayer,display=yes

# Compare and create map layer if map layer does not exists or force re-compare
if ($gEXISTS != "yes" || $?ForceReCompare) then
	# Comparing
	COM top_tab,tab=1-Up Parameters Page
	COM show_parameters_page,action=lyrCompare
	COM rv_tab_empty,report=graphic_compare,is_empty=yes
	COM graphic_compare_res,layer1=$ThisLayer,\
	job2=$MyJob,step2=$MyStep,layer2=$RefLayer,layer2_ext=,tol=0.1,resolution=$MyResolution,area=global,ignore_attr=,map_layer_prefix=map_,consider_sr=no
	COM rv_tab_view_results_enabled,report=graphic_compare,is_enabled=yes,serial_num=-1,all_count=-1 
	
	# Save map layer to the job
	COM save_job,job=$MyJob,override=no
	COM check_inout,job=$MyJob,mode=in,ent_type=job

	# Open compare results list
	COM rv_tab_empty,report=graphic_compare,is_empty=no
	COM editor_results_show,action=graphic_compare,is_end_results=yes
	COM zoom_mode,zoom=zoom
	COM edt_tab_select,report=graphic_compare
	COM top_tab,tab=LayerCompareResults
	COM show_component,component=Result_Viewer,show=yes,width=750,height=220
endif
	
COM display_layer,name=$MapLayer,display=yes
COM zoom_home

# Open the checklist tab so we can run the action if needed
COM top_tab,tab=Checklists
COM chklist_open,chklist=$MyChecklist
COM chklist_show,chklist=$MyChecklist

exit 0

