Object subclass: #Account
    instanceVariableNames: 'balance'
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Finance'.

Account>>initialize
    balance := 0.

Account>>deposit: amount
    balance := balance + amount.

Account>>withdraw: amount
    (balance >= amount)
        ifTrue: [balance := balance - amount]
        ifFalse: [Transcript show: 'Insufficient funds.'; cr].

Account>>balance
    ^balance.
