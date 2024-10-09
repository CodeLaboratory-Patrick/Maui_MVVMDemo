# MVVM Pattern in .NET MAUI

## What is the MVVM Pattern?
**MVVM** stands for **Model-View-ViewModel**. It is a design pattern commonly used in software engineering, particularly in applications built using frameworks like **.NET MAUI**, **WPF**, and **Xamarin**. The MVVM pattern helps in separating the user interface from the business logic, promoting code maintainability, reusability, and testability. This separation allows developers to work independently on the UI (View) and logic (Model and ViewModel), which is especially useful in larger applications.

The **MVVM pattern** consists of three main components:
- **Model**: Represents the application's data and business logic.
- **View**: Represents the user interface (UI), which displays the data and interacts with the user.
- **ViewModel**: Acts as a bridge between the **View** and the **Model**. It contains the presentation logic and handles data binding to keep the UI in sync with the data.

<img width="569" alt="Screenshot 2024-10-09 at 9 08 34 AM" src="https://github.com/user-attachments/assets/2d951ec0-aaf3-4985-8ff0-b93a489bfb64">

## Key Features of MVVM
- **Data Binding**: The **ViewModel** is bound to the **View** to ensure that the UI is automatically updated when the data changes.
- **Commanding**: Commands are used in the **ViewModel** to handle user interactions from the **View** without directly manipulating the **View** itself.
- **Separation of Concerns**: MVVM separates the UI (View) from the application logic, making the code more maintainable and easier to test.
- **Testability**: The **ViewModel** and **Model** can be unit tested without requiring a user interface.

## Overview of MVVM Components
| Component   | Description                                                                                                                                                   | Example                     |
|-------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------|
| **Model**   | Represents the data, state, and business rules. Contains pure data objects and logic related to data access.                                                  | `User` class with properties like `Name` and `Age`. |
| **View**    | Represents the user interface that displays the data and receives user input. It is defined in **XAML** and typically bound to properties in the ViewModel.   | **XAML** page (e.g., `MainPage.xaml`). |
| **ViewModel** | Acts as an intermediary between the **Model** and the **View**. It exposes data through **properties** and handles commands that the **View** can execute. | `MainViewModel` class that contains properties and commands. |

## Example of MVVM in .NET MAUI

### 1. Model
The **Model** is a simple class that represents the data structure.
```csharp
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### 2. ViewModel
The **ViewModel** contains properties and commands that the **View** can bind to. It also implements the **INotifyPropertyChanged** interface to notify the UI when data changes.
```csharp
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

public class MainViewModel : INotifyPropertyChanged
{
    private string userName;
    public string UserName
    {
        get => userName;
        set
        {
            if (userName != value)
            {
                userName = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand SubmitCommand { get; }

    public MainViewModel()
    {
        SubmitCommand = new Command(OnSubmit);
    }

    private void OnSubmit()
    {
        // Logic when submit is pressed.
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
- **UserName**: A property that is bound to the UI element in the View, with `OnPropertyChanged()` called whenever the property changes to update the UI.
- **SubmitCommand**: A command that handles user interaction (e.g., button click).
- **INotifyPropertyChanged**: Implemented to notify the View whenever properties change.

### 3. View (XAML)
The **View** is defined in **XAML** and binds to properties in the **ViewModel**.
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MauiApp.MainPage">
    <ContentPage.BindingContext>
        <local:MainViewModel />
    </ContentPage.BindingContext>

    <StackLayout Padding="20">
        <Entry Text="{Binding UserName}" Placeholder="Enter your name" />
        <Button Text="Submit" Command="{Binding SubmitCommand}" />
    </StackLayout>
</ContentPage>
```
- **BindingContext**: Sets the binding context of the page to the `MainViewModel`.
- **Entry**: Binds its `Text` property to the `UserName` property in the **ViewModel**, allowing two-way data binding.
- **Button**: Binds its `Command` property to `SubmitCommand` to handle user interaction.

## When to Use MVVM
- **Separation of Concerns**: MVVM is useful when you want to keep the UI code and logic separate. This separation makes the application easier to maintain and extend.
- **Data Binding**: When your application requires frequent updates between the UI and the underlying data, MVVM allows for efficient data binding that keeps everything in sync.
- **Testable Code**: If you need to write unit tests for your application, MVVM provides testable classes in the form of **Models** and **ViewModels**, since they do not depend on the actual UI.
- **Reusability**: The ViewModel can be reused across different Views, making the codebase more modular and reusable.

For example, in an application that requires input forms, displaying data lists, or other interactions that involve data processing, **MVVM** can simplify both development and testing. It keeps user interaction code away from data management logic, leading to a cleaner and more maintainable structure.

## Summary
- **MVVM** (Model-View-ViewModel) is a design pattern that separates data, UI, and logic to ensure maintainability, reusability, and testability.
- **Model**: Represents the application's data and business logic.
- **View**: Represents the UI elements and how data is displayed to users.
- **ViewModel**: Acts as a mediator between the View and Model, exposing properties and commands for data binding.
- **Use Cases**: MVVM is suitable for applications where separation of logic from UI is crucial, data needs to be frequently updated in the UI, or for reusable and testable components.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - MVVM in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/architecture/mvvm)
- [MVVM Pattern Overview](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)

# CollectionView SelectionMode in .NET MAUI

## What is `<CollectionView SelectionMode>` in .NET MAUI?
In .NET MAUI, **CollectionView** is a powerful control used to display a collection of data in a flexible and customizable way. The **SelectionMode** property in **CollectionView** determines how items in the collection can be selected by the user. This property is crucial for handling user interactions when selecting one or more items from a list of data.

### SelectionMode Options
The **SelectionMode** property has the following options:

| SelectionMode    | Description                                                                                     | Use Case                                        |
|------------------|-------------------------------------------------------------------------------------------------|-------------------------------------------------|
| **None**         | No selection is allowed. The items are displayed, but users cannot select them.                | Display-only lists with no need for selection.  |
| **Single**       | Only a single item can be selected at a time. Selecting a new item will deselect the previous.  | Use when only one item should be selectable, such as a settings list. |
| **Multiple**     | Multiple items can be selected at the same time.                                                | Use for scenarios where multiple selections are needed, like selecting multiple items for a bulk action. |

### Example of CollectionView with SelectionMode
Below is an example of a **CollectionView** with different **SelectionMode** settings.

#### 1. Single Selection Example
In this example, only one item can be selected at a time. If the user selects a new item, any previously selected item will be deselected.

```xml
<CollectionView ItemsSource="{Binding Items}" SelectionMode="Single">
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <StackLayout Padding="10">
                <Label Text="{Binding Name}" FontSize="Large" />
            </StackLayout>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```
- **SelectionMode="Single"**: This setting means only one item in the **CollectionView** can be selected at any given time.
- This is useful when the user needs to pick one item from a list, such as choosing a category.

#### 2. Multiple Selection Example
In this example, the user can select multiple items.

```xml
<CollectionView ItemsSource="{Binding Items}" SelectionMode="Multiple">
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <StackLayout Padding="10">
                <Label Text="{Binding Name}" FontSize="Large" />
            </StackLayout>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```
- **SelectionMode="Multiple"**: This allows the user to select multiple items simultaneously.
- This setting is helpful in situations like selecting multiple files for deletion or tagging items.

#### 3. No Selection Example
In this example, items in the **CollectionView** are displayed without allowing the user to select them.

```xml
<CollectionView ItemsSource="{Binding Items}" SelectionMode="None">
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <StackLayout Padding="10">
                <Label Text="{Binding Name}" FontSize="Large" />
            </StackLayout>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```
- **SelectionMode="None"**: Users cannot select any items.
- This is useful when the data is only meant to be viewed without any interactive selection, such as displaying read-only information.

## When to Use Each SelectionMode
### 1. **None**
- **Use Case**: When you want to display data without the need for user interaction. For example, showing a list of read-only items like news headlines or a gallery where selection is not relevant.

### 2. **Single**
- **Use Case**: When the user must choose only one option from a list. Examples include selecting a preferred shipping option or choosing a contact from a list.
- **Advantages**: Limits user selection to one, ensuring only one action is applicable at any time.

### 3. **Multiple**
- **Use Case**: When you need to allow the user to select multiple items. Examples include selecting multiple photos to upload or items to delete.
- **Advantages**: Provides flexibility for users to interact with multiple items simultaneously, which is useful in bulk actions.

## Summary of SelectionMode Options
| SelectionMode    | Description                          | Common Use Cases                           |
|------------------|--------------------------------------|--------------------------------------------|
| **None**         | No selection allowed                 | Display-only lists                         |
| **Single**       | One item can be selected             | Settings lists, option pickers             |
| **Multiple**     | Multiple items can be selected       | Bulk actions, multi-item operations        |

## Practical Scenario
Consider an application where you display a list of documents. Using **Single** selection would make sense if the user needs to view or edit a specific document. However, if you allow the user to delete multiple documents at once, **Multiple** selection would be more suitable. If you simply want to show a read-only list of available documents without allowing selection, then **None** would be appropriate.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - CollectionView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/collectionview)
- [Xamarin CollectionView Documentation (Concept Similarity)](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview)

# IValueConverter in .NET MAUI

## What is IValueConverter in .NET MAUI?
**IValueConverter** is an interface in **.NET MAUI** that allows you to create custom logic to convert data between the **ViewModel** and the **View**. It is primarily used for **data binding** scenarios, enabling you to transform data in a format that is suitable for display in the user interface.

The **IValueConverter** interface has two primary methods:
- **Convert**: Transforms data from the source (e.g., the ViewModel) to the target (e.g., the View). This is used when you need to display data in the UI in a different format than how it is stored.
- **ConvertBack**: Transforms data from the target (e.g., the View) back to the source (e.g., the ViewModel). This method is optional and used mainly in two-way data binding scenarios.

### Key Features of IValueConverter
- **Data Transformation**: Converts data from one type to another, making it suitable for display.
- **Two-Way Binding**: Allows data conversion in both directions, depending on the application's requirements.
- **Custom Conversion Logic**: Developers can create custom conversion logic, such as formatting numbers, changing colors, or transforming boolean values.
- **Reusable**: Converters are reusable across different views, reducing code duplication and improving maintainability.

## Example of IValueConverter in .NET MAUI
Below is an example of how to implement **IValueConverter** to convert a boolean value into a color for display in the UI.

### 1. Implementing the IValueConverter Interface
Create a converter class by implementing the **IValueConverter** interface:

```csharp
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

public class BooleanToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Colors.Green : Colors.Red;
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```
- **Convert Method**: The `Convert` method takes a boolean value and returns **Green** if `true` or **Red** if `false`. This method is used to format the data before it is displayed in the UI.
- **ConvertBack Method**: The `ConvertBack` method is not implemented here, as it is not needed in this example. In scenarios where you need two-way binding, you can implement this method to convert data from the UI back to the ViewModel.

### 2. Using the Converter in XAML
To use the converter in **XAML**, you first need to define it as a resource and then bind it to a property:

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:YourNamespace"
             x:Class="MauiApp.MainPage">
    <ContentPage.Resources>
        <ResourceDictionary>
            <local:BooleanToColorConverter x:Key="BoolToColorConverter" />
        </ResourceDictionary>
    </ContentPage.Resources>

    <StackLayout Padding="20">
        <Label Text="Status"
               TextColor="{Binding IsAvailable, Converter={StaticResource BoolToColorConverter}}"
               FontSize="Large" />
    </StackLayout>
</ContentPage>
```
- **ResourceDictionary**: Defines the `BooleanToColorConverter` as a resource that can be reused throughout the **ContentPage**.
- **Converter**: The **Label** binds its `TextColor` property to a boolean property (`IsAvailable`) in the **ViewModel** and uses the `BoolToColorConverter` to determine the color.

### Explanation of Components
- **Convert Method**: Converts the source value (`IsAvailable`) into a target value (`TextColor`) suitable for display.
- **Converter in XAML**: Allows developers to easily apply custom formatting rules directly in the XAML without needing to write code-behind logic.

## When to Use IValueConverter
### 1. **Formatting Data for Display**
- **Use Case**: When data in the **ViewModel** needs to be formatted before being displayed in the **View**. For example, converting a **DateTime** object to a formatted date string or transforming a numeric value to a currency format.
- **Example**: Displaying a user's balance in currency format by converting a `double` value to a formatted string like `"$1,000.00"`.

### 2. **Conditional Formatting**
- **Use Case**: When the visual representation of data depends on a condition. For example, changing the color of a **Label** based on whether a boolean value is `true` or `false`.
- **Example**: Using **BooleanToColorConverter** to change the color of a **Label** to indicate status (e.g., `Green` for available and `Red` for unavailable).

### 3. **Data Transformation**
- **Use Case**: When a specific transformation is required for data binding, such as converting a `bool` to `string` ("Yes" or "No") or converting numbers into a different format.
- **Example**: Displaying `"Yes"` or `"No"` based on a boolean property value.

## Summary of IValueConverter Use Cases
| Scenario                   | Description                                      | Example                                      |
|----------------------------|--------------------------------------------------|----------------------------------------------|
| **Formatting Data**        | Converts data for display in a specific format   | Convert `DateTime` to `"MM/dd/yyyy"` format  |
| **Conditional Formatting** | Changes UI elements based on conditions          | Convert `bool` to color (`Green`/`Red`)      |
| **Data Transformation**    | Transforms data type to a different presentation | Convert `bool` to `"Yes"` or `"No"`          |

## Practical Scenario
Consider a scenario where you have a list of products in your application, and each product has an **availability status** (`true` or `false`). You want to display the product's status as a **Label** with a background color indicating availability (green for available, red for unavailable). By using an **IValueConverter**, you can bind the boolean property to the `BackgroundColor` of the **Label** and easily achieve this effect without needing additional code behind, simplifying the UI logic.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - Data Binding in MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding)
- [IValueConverter Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.windows.data.ivalueconverter)

## Understanding the Code.

![Screenshot 2024-10-09 at 10 48 15 AM](https://github.com/user-attachments/assets/5bec5c14-b6c9-4905-9598-49e6ffed4d39)

The provided code represents a class named **BoolConverter** that implements the **IValueConverter** interface. In .NET MAUI, **IValueConverter** is used to convert data from one type to another for display in the user interface. This class allows you to add custom conversion logic between the **ViewModel** and the **View** during data binding.

## Breakdown of the Code

### 1. Class Declaration
```csharp
public class BoolConverter : IValueConverter
```
- **`public class BoolConverter`**: This declares a public class named **BoolConverter**.
- **`: IValueConverter`**: The **BoolConverter** class implements the **IValueConverter** interface. This means that the class must provide definitions for the methods defined by **IValueConverter**: **Convert** and **ConvertBack**.

### 2. Convert Method
```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    throw new NotImplementedException();
}
```
- **`public object Convert`**: This is the implementation of the **Convert** method required by the **IValueConverter** interface.
- **Parameters**:
  - **`object value`**: The value being passed from the data source (e.g., from the ViewModel to the View).
  - **`Type targetType`**: The type of the target property, meaning the data type of the property that this value is bound to in the UI.
  - **`object parameter`**: An optional parameter that may be used to influence the conversion logic.
  - **`CultureInfo culture`**: Provides culture-specific information for the conversion (e.g., date format, currency format).
- **`throw new NotImplementedException();`**: This line of code throws a **NotImplementedException**, indicating that the method hasn't been implemented yet. It serves as a placeholder, telling the developer that they need to provide logic to convert the incoming value to the appropriate type for the target.
- **Purpose of Convert**: This method is used to convert the value from the source type to a type suitable for the UI. For example, converting a `bool` value to a color or a visibility state.

### 3. ConvertBack Method
```csharp
public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
{
    throw new NotImplementedException();
}
```
- **`public object ConvertBack`**: This is the implementation of the **ConvertBack** method required by the **IValueConverter** interface.
- **Parameters**:
  - **`object value`**: The value being passed from the target property (e.g., from the View to the ViewModel).
  - **`Type targetType`**: The type of the target property in the source, meaning the data type in the ViewModel to which this value needs to be converted.
  - **`object parameter`**: An optional parameter that may influence the conversion logic.
  - **`CultureInfo culture`**: Provides culture-specific information for the conversion.
- **`throw new NotImplementedException();`**: This line of code throws a **NotImplementedException**, indicating that the method hasn't been implemented yet. In many cases, **ConvertBack** might not be needed, so developers may choose to leave it unimplemented if only one-way binding is required.
- **Purpose of ConvertBack**: This method is used to convert the value from the target type (UI) back to the source type (ViewModel). For example, if a user interacts with a control (e.g., a switch that sets a value to true or false), the **ConvertBack** method would convert the updated value back to its original data type.
- 
## Summary
- **BoolConverter** is a custom class that implements **IValueConverter** to provide custom conversion logic for data binding in .NET MAUI applications.
- **Convert Method**: Converts data from the source to the target type, typically used to format data for the UI.
- **ConvertBack Method**: Converts data from the target back to the source type, used in two-way binding scenarios, but can be left unimplemented if not needed.
- **Practical Use**: BoolConverter is commonly used to convert boolean values to colors, visibility states, or other data formats suitable for UI representation.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - IValueConverter](https://learn.microsoft.com/en-us/dotnet/api/system.windows.data.ivalueconverter)
