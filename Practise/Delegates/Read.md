In C#, actions and functions are both delegates used to encapsulate methods, but they differ mainly in their return types:

Action:

Represents a delegate that encapsulates a method that does not return a value (void).
Can take 0 to 16 parameters.
Function (Func<T, TResult>):

Represents a delegate that encapsulates a method that returns a value (TResult).
Can take 0 to 16 input parameters, with the last parameter being the return type.


| Feature | Action | Func |
| :-- | :-- | :-- |
| Return type | void (no return value) | Returns a value (specified in the delegate) |
| Input parameters | 0-16 | 0-16 |
| Usage | Used for operations without a return value | Used for calculations, transformations, or returning results |