# Inventory Reordering System

## Introduction
The Inventory Reordering System ensures warehouse inventory levels meet forecasted demand while minimizing reordering costs. It calculates the optimal number of units to reorder for each item based on its current stock, forecasted demand, reorder cost per unit, and batch size.

## Features
- Ensures no stockouts by meeting forecasted demand.
- Minimizes total reordering costs.
- Considers batch size constraints for cost optimization.
- Outputs a reordering plan specifying the item ID and units to order.

## Algorithm Overview
1. **Input**: A list of items with the following attributes:
   - `ItemId`: Unique identifier for the item.
   - `CurrentStock`: Current inventory level.
   - `ForecastedDemand`: Forecasted demand for the next period.
   - `ReorderCostPerUnit`: Cost per unit for reordering.
   - `BatchSize`: Units per batch.
2. **Process**:
   - Calculate the required units to meet forecasted demand.
   - Determine the number of batches needed to fulfill the demand, ensuring the quantity is a multiple of the batch size.
   - Generate a reordering plan.
3. **Output**: A list of items with the `ItemId` and the number of units to reorder.

## How to Run the System
### Prerequisites
- Install the .NET SDK on your machine.
- Use a code editor such as Visual Studio or Visual Studio Code.

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/subitha990527/Inventory-Reordering-System.git
   ```
2. Navigate to the project directory.
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. The console will display the reordering plan based on the provided sample data.

## Sample Input and Output
### Input Data:
```csharp
List<InventoryItem> inventoryItems = new List<InventoryItem>
{
    new InventoryItem(itemId: 1, currentStock: 50, forecastedDemand: 100, reorderCostPerUnit: 10, batchSize: 20),
    new InventoryItem(itemId: 2, currentStock: 30, forecastedDemand: 60, reorderCostPerUnit: 5, batchSize: 15),
    new InventoryItem(itemId: 3, currentStock: 80, forecastedDemand: 70, reorderCostPerUnit: 8, batchSize: 10),
    new InventoryItem(itemId: 4, currentStock: 10, forecastedDemand: 50, reorderCostPerUnit: 12, batchSize: 25)
};
```

### Output:
```
Reordering Plan:
Item ID: 1, Units to Order: 60
Item ID: 2, Units to Order: 30
Item ID: 4, Units to Order: 50
```

## Conclusion
The Inventory Reordering System efficiently calculates optimal reorder quantities, ensuring stock levels meet forecasted demand while minimizing costs. It is modular, easy to understand, and ready for real-world applications.
