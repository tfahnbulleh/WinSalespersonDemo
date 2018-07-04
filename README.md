# WinSalespersonDemo

Write a program named SalespersonDemo that instantiates objects using classes named
RealEstateSalesperson and GirlScout. Demonstrate that each object can use a SalesSpeech() method
appropriately. Also, use a MakeSale() method two or three times with each object and display the final
contents of each object’s data field. First, create an abstract class named Salesperson. Fields include
first and last names; the Salesperson constructor requires both these values. Include properties for the
fields. Include a method that returns a string that holds the Salesperson’s full name – the first and last
names separated by a space. Then perform the following tasks:
 Create two child classes of Salesperson: RealEstateSalesperson and GirlScout. The
RealEstateSalesperson class contains fields for total value sold in dollars and total commission
earned (both of which are initialized to 0), and a commission rate field required by the class
constructor. The GirlScout class includes a field to hold the number of boxes of cookies sold,
which is initialized to 0. Include properties for each field.
 Create an interface named ISellable that contains two methods: SalesSpeech() and MakeSale().
In each RealEstateSalesperson and GirlScout class, implement SalesSpeech() to display an
appropriate one- or two-sentence sales speech that the objects of the class could use. In the
RealEstateSalesperson class, implement the MakeSale() method to accept an integer dollar
value for a house, add the value to the RealEstateSalesperson’s total value sold, and compute 
the total commission earned. In the GirlScout class, implement the MakeSales() method to
accept an integer representing the number of boxes of cookies sold and add it to the total field.
