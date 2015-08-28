Lorem.NET
===============

A .NET library for all things random!

Usage
---------------

### Text Helpers

```csharp
// this will generate a string with three words:
string words = LoremNET.Lorem.Words(3);

// this will generate a string with two to five words:
string words = LoremNET.Lorem.Words(2, 5);

// this will generate a string with five to ten words with "uppercaseFirstLetter" set to "false" and "includePunctuation" set to "true":
string words = LoremNET.Lorem.Words(5, 10, false, true);

// a sentence is the same as "Words" except that it will include punctuation by default and will include a "." at the end of a string:
string sentence = LoremNET.Lorem.Sentence(5, 10);

// a paragraph is a string composed of multiple sentences; this paragraph will have five to six words per sentence, and four to ten sentences:
string paragraph = LoremNET.Lorem.Paragraph(5, 6, 4, 10);

// paragraphs is an array of paragraphs; this method will have eight to nine words per sentence, four to five sentences per paragraph, and one to three paragraphs:
string[] paragraphs = LoremNET.Lorem.Paragraphs(8, 9, 4, 5, 1, 3);
```

### Extras

```csharp
// this will generate a random valid email address:
string email = LoremNET.Lorem.Email();

// this will generate a random hex number (i.e. a color)
string hex = LoremNET.Lorem.HexNumber();

// this will generate a random DateTime object between 1/1/1950 and the current DateTime:
DateTime dateTime = LoremNET.Lorem.DateTime();

// this will generate a random DateTime object between 1/1/1995 and 12/31/2020:
DateTime dateTime = LoremNET.Lorem.DateTime(new DateTime(1995, 1, 1), new DateTime(2020, 12, 31))

// this will return "true" 55% of the time:
bool isTruth = LoremNET.Lorem.Chance(55, 100);

// this will randomly select an item from the group:
string[] numbers = GetNumbers();
string number = LoremNET.Lorem.Random(numbers);

// this will randomly select a value from the enum:
MyEnum value = LoremNET.Lorem.RandomEnum<MyEnum>(); 

```

### RandomHelper

Lorem.NET includes a thread-safe System.Random instance.

```csharp
int i = LoremNET.RandomHelper.Instance.Next(1, 2);
```

### Extending the Class

If you want to extend the class to add more methods, go right ahead!

```csharp
namespace LoremNET
{
    public partial class Lorem
    {
        public static string Email(string domain)
        {
            return Email().Replace(".com", string.Format(".{0}", domain));
        }
    }
}
```
