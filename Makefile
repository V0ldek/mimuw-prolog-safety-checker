model: model.pl
	swipl --goal=verify --stand_alone=true -O -o model -c ./model.pl

clean:
	rm model