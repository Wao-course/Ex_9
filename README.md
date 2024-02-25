# Lecture 10 Exercises

## Exercise 1 - Handling concurrency conflicts in database updates

### Lab 1.1

Take as a starting point the project ConcurrencyLab1 (located under exercises) - get this program running on your computer - may require changes in the connection string.

### Lab 1.2

Add code that simulates running on another thread, thereby provoking a concurrency conflict. You can get inspiration from the code shown on slide 9.

### Lab 1.3

Write the code that, using the Concurrency token, solves the problem shown on slide 3. And test that it works as expected.

### Lab 1.4

Create a new .Net console project that demonstrates the use of timestamp to resolve the concurrency conflict from lab 1.2.
And test that it works as expected.

### Lab 1.5

Could this concurrency issue have been solved by design?

## Exercise 2 - Handling disconnected concurrent update issues

### Lab 2.1

Get the project DisconnectedConcurrentUpdate (located under exercises) running on your computer. And recreate the scenario on slide 24 by accessing this api (HttpPatch("new-salary/{id}/{new_salary}")) using Postman and Swagger to simulate 2 different users.

### Lab 2.2

Enhance the project with the required code to handle disconnected concurrent updates by use of a Concurrency token. If a concurrency conflict is discovered then an appropriate error message is send back. And verify that your code works.

### Lab 2.3

Use a timestamp to discover a concurrency conflict.
