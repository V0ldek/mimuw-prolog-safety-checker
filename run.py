#!/bin/python3
from os import system

arr = [
    (2, 'peterson.txt'),
    (3, 'peterson3.txt'),
    (3, 'peterson3-ext.txt'),
    (2, 'peterson-bad0.txt'),
    (2, 'peterson-bad1.txt'),
    (2, 'peterson-bad2.txt'),
    (2, 'trivial.txt'),
    (2, 'unsafe.txt'),
    (2, 'dekker.txt'),
    (2, 'dekker2.txt'),
    (2, 'dekker-deadlock.txt'),
    (2, 'dekker-bad0.txt'),
    (2, 'incFive.txt'),
    (2, 'incThree.txt'),
    (2, 'divide.txt'),
    (2, 'section-goto-only.txt')
]

for (n, f) in arr:
    print('==========')
    print(f)
    print('==========')
    system('./stud ' + str(n) + ' \'../../test/' + f + '\'')

print("./stud")
system('./stud')
print("./stud 1")
system('./stud 1')
print("./stud 0 ../../test/peterson.txt")
system('./stud 0 ../../test/peterson.txt')
print("./stud 1 ../../test/peerson.txt")
system('./stud 1 ../../test/peerson.txt')