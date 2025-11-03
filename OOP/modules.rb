# This code is AI generated
# Define a module named 'Grettings'
module Greetings
  def say_hello
    puts "Hello from the Greetings module!"
  end

  def say_goodbye
    puts "Goodbye from the Greetings module!"
  end
end

# Define a class 'Person' and include the 'Greetings' module
class Person
  include Greetings # This brings the module's methods into the class

  def initialize(name)
    @name = name
  end

  def introduce
    puts "My name is #{@name}."
  end
end

# Define another class 'Robot' and include the 'Greetings' module
class Robot
  include Greetings

  def initialize(model)
    @model = model
  end

  def identify
    puts "I am a #{@model} model robot."
  end
end

# Create instances of the classes
person = Person.new("Alice")
robot = Robot.new("C-3PO")

# Call methods from the included module
person.say_hello
person.introduce
robot.say_goodbye
robot.identify