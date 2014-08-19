Lorem.NET
===============

A .NET library for all things random!

Usage
---------------

### Text Helpers

```csharp
// this will generate a string with three words:
string words = Lorem.Words(3);

// this will generate a string with two to five words:
string words = Lorem.Words(2, 5);

// this will generate a string with five to ten words with "uppercaseFirstLetter" set to "false" and "includePunctuation" set to "true":
string words = Lorem.Words(5, 10, false, true);

// a sentence is the same as "Words" except that it will include punctuation by default and will include a "." at the end of a string:
string sentence = Lorem.Sentence(5, 10);

// a paragraph is a string composed of multiple sentences; this paragraph will have five to six words per sentence, and four to ten sentences:
string paragraph = Lorem.Paragraph(5, 6, 4, 10);

// paragraphs is an array of paragraphs; this method will have eight to nine words per sentence, four to five sentences per paragraph, and one to three paragraphs:
string[] paragraphs = Lorem.Paragraphs(8, 9, 4, 5, 1, 3);
```

### Extras

```csharp
// this will generate a random valid email address:
string email = Lorem.Email();

// this will generate a random DateTime object:
DateTime dateTime = Lorem.DateTime();

// this will return "true" 55% of the time:
bool isTruth = Lorem.Chance(55, 100);

// this will randomly select an item from the group:
string[] numbers = GetNumbers();
string number = Lorem.Random(numbers);
```

### RandomHelper

Lorem.NET includes a thread-safe System.Random instance.

```csharp
int i = Lorem.NET.RandomHelper.Instance.Next(1, 2)
```