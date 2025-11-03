# This code is AI generated
# Example of Instance Variables and Class Variables in Ruby
    class Dog
      def initialize(name)
        @name = name # @name is an instance variable
      end

      def bark
        puts "#{@name} says Woof!"
      end
    end

    fido = Dog.new("Fido")
    buddy = Dog.new("Buddy")

    fido.bark  # Output: Fido says Woof!
    buddy.bark # Output: Buddy says Woof!

    class Counter
      @@count = 0 # @@count is a class variable

      def initialize
        @@count += 1
      end

      def self.total_instances
        @@count
      end
    end

    obj1 = Counter.new
    obj2 = Counter.new
    obj3 = Counter.new

    puts Counter.total_instances # Output: 3