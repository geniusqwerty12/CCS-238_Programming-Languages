# This code implements a simple stack class in Ruby
# taken from the ebook
class StackClass
    # Constructor
    def initialize
        @stackRef = Array.new(100)
        @maxLen = 100
        @topIndex = -1
    end

    # push method
    def push(number)
        if @topIndex == @maxLen
            puts "Error in push - stack is full"
        else
            @topIndex = @topIndex + 1
            @stackRef[@topIndex] = number
        end
    end

    # pop method
    def pop
        if empty
            puts "Error in pop - stack is empty"
        else
            @topIndex = @topIndex - 1
        end
    end

    # top method
    def top
        if empty
            puts "Error in top - stack is empty"
        else
            @stackRef[@topIndex]
        end
    end
end

myStack = StackClass.new
myStack.push(29)
puts "Top element is (should be 29): #{myStack.top}"
myStack.pop
puts "Top element is (should be 42): #{myStack.top}"
myStack.pop
# The following pop should produce an
# error message - stack is empty
myStack.pop