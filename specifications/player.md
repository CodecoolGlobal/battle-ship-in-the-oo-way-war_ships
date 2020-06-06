In this class named Player we got 4 fields:

--> Ocean type field called playerOcean - we initialize player ocean (field where player will put his ships)
--> string called Name - later name of player will be asiigned to this field
--> boolean called IsComp - later boolean value (depending on whather the player is computer) will be assigned to this field
--> integer called ShotsFired - store information about fired shots by player

Class Player got two constructors; one with 2 parameters and second one with 3 parameters 

-bool isCpu - value of this parameter will be assigned to field IsComp
-string name - value of this parameter will be assigned to field Name

Last thing in this contructor is initializing new Ocean object and assigned it to field playerOcean

In class player we created 3 methods:

1) EffectOnAttack - this method got one parameter Square square and return valuee of this method is integer. 
                  - this method is responsible for geeting integer depends on effect of player attack:
                    0 - miss again
                    1 - miss but first time
                    2 - no miss, but already shot (it means that we )



