# -*- coding: utf-8 -*- 
import re
file=open('item.xml','r+')
lines=file.readlines()
file2=open('item2.xml','w+')
for line in lines:
	matchline=re.findall(r'<message.*</message>',line)
	#print matchline
	if len(matchline)>0:
		id=line[line.find('="')+2:line.find('">')]
		name=line[line.find('CDATA[')+6:line.find(']]')]
		if len(name)<30 :
			file2.write(id+"\n")
			file2.write(name+"\n")
			print id+" "+name