#! /usr/bin/python3.5

from xml.dom import minidom

playTestResult = minidom.parse('/Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/playTest.xml')
playTestCase = playTestResult.getElementsByTagName('test-case')

print('\n Play Tests Results\n')

for elem in playTestCase:
    if elem.attributes['result'].value == "Passed":
        print(('\033[01;32m Test Name: ')+elem.attributes['name'].value)
        print(('\033[01;32m Test Full Name: ')+elem.attributes['fullname'].value)
        print(('\033[01;32m Tested Method: ')+elem.attributes['methodname'].value)
        print(('\033[01;32m Test Result: ')+elem.attributes['result'].value)
        print('\n')
    else:
        print(('\033[01;31m Test Name: ')+elem.attributes['name'].value)
        print(('\033[01;31m Test Full Name: ')+elem.attributes['fullname'].value)
        print(('\033[01;31m Tested Method: ')+elem.attributes['methodname'].value)
        print(('\033[01;31m Test Result: ')+elem.attributes['result'].value)
        print('\n')
