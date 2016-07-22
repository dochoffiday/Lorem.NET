Lorem Class
===========

The main class for generating random content.

Namespace
---------
LoremNET

Assembly
--------

* Lorem.DNX.NET
* Lorem.Universal.NET

Methods
-------

Chance(int successes, int attempts)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns true *successes* times out of *attempts*.

successes
  The number of times the functions should return true (on average) in *attempts* 
  number of attempts.  
attempts 
  The number of attempts used to scale *successes*

DateTime(int startYear = 1950, int startMonth = 1, int startDay = 1)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random DateTime greater than or equal to the given date and 
less than DateTime.Now.

startYear
  The minimum year (default 1950).
startMonth
  The minimum month (default 1).
startDay
  The minimum day (default 1).

The smallest difference between two different results will be one minute. 

DateTime(DateTime min)
~~~~~~~~~~~~~~~~~~~~~~

Returns a random DateTime greater than or equal to *min* and less than 
DateTime.Now.

min
  The minimum date.

The smallest difference between two different results will be one minute.

DateTime(DateTime min, DateTime max)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random DateTime greater than or equal to *min* and less than *max*.

min
  The minimum date.
max
  The maximum date.

The smallest difference between two different results will be one minute.
The code was originally taken from http://stackoverflow.com/a/1483677/234132.

Email()
~~~~~~~

Returns a random email address of the type random1@random2.com  This does not
randomise the top level domain.

Enum<TEnum>()
~~~~~~~~~~~~~

Returns a random item from *TEnum*.  Throws an *ArgumentException* if *TEnum* is
not an enum.

