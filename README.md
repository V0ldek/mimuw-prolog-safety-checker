# Prolog Safety Checker

Tests and grader tools published for students submitting solutions to the assignment.

The problem statement is to create a Prolog program that verifies correctness of a mutual exclusion algorithm written in a very simple imperative language running on a system with N processes with shared memory.

The expected output is an information on whether the program is correct and in case it is not a trace of program execution that is more or less a sequence of pairs (process number, executed instruction) that leads to two processes being in the mutual exclusion zone at the same time.

All Prolog code is meant for SWI Prolog.

**Model solution will be made available at a later date.**

## Tests

Tests are located in the test directory. The tests were run on 2 processes unless specified otherwise.

- `dekker.txt` -- correct implementation of Dekker's mutual exclusion algorithm.
- `dekker2.txt` -- alternative, correct version of Dekker's mutex algorithm .
- `dekker-bad0.txt` -- incorrect version of Dekker's mutex algorithm.
- `dekker-deadlock.txt` -- version of Dekker's algorithm that allows deadlocks, but is nonetheless correct w.r.t. the assignment.
- `divide.txt` -- a correct program checking the implementation of the division operator, in particular it works for correctly implemented integral division where `5/2=2` is true.
- `incFive.txt` -- incorrect program, courtesy of dr Mirosława Miłkowska.
- `incThree.txt` -- incorrect program, courtesy of dr Mirosława Miłkowska.
- `peterson.txt` -- correct implementation of Peterson's mutex algorithm, available to students as an example program.
- `peterson3.txt` -- incorrect version of Peterson's algorithm ran on 3 processes.
- `peterson3-ext.txt` -- a more complicated version of `peterson3`, also for 3 processes.
- `peterson-bad0.txt` -- incorrect example program.
- `peterson-bad1.txt` -- incorrect example program.
- `peterson-bad2.txt` -- incorrect example program.
- `section-goto-only.txt` -- incorrect program testing an edge case where the only entry to the mutex zone is via a goto statement.
- `trivial.txt` -- incorrect program where the first statement is an unprotected mutex zone.
- `unsafe.txt` -- incorrect example program.

## `run.py`

The python script contains all tests ran automatically on submissions. It is assumed it is ran in a location where `../../test` refers to the test directory.

## Parser

The Parser is a simple C# program that takes a trace and parses it into a Prolog list. It works on the (correct) assumption that 95% of all students provided their output more or less in the form of:

 Process 2: statement 3
 Process 0: statement 1
 Process 0: statement 2
 ...
 
This allows quick testing of correctness of traces.

It works in two modes, as some students provided a straightforward trace of execution while others used a format:
  Process 2: will execute statement 4 on the next move
  Process 0: will execute statement 2 on the next move
  ...

The program can be ran using `dotnet`

```
cd Parser
dotnet build
dotnet run
```

## Trace

A trace in Prolog list format can be tested by using `trace.pl` and pasting the trace there, and then using:

```prolog
consult(trace), output(Trace), isValidOutput(3, './test/peterson3.txt', Trace, [0, 1]).
```

with the model solution open in `swipl`.

## Copyright

The example tests and the assignment were designed by dr Mirosława Miłkowska, MIMUW.
Everything else is my own work.
