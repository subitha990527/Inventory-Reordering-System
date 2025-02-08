
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class InventoryItem
{
    public int ItemId { get; set; }
    public int CurrentStock { get; set; }
    public int ForecastedDemand { get; set; }
    public int ReorderCostPerUnit { get; set; }
    public int BatchSize { get; set; }

    public InventoryItem(int itemId, int currentStock, int forecastedDemand, int reorderCostPerUnit, int batchSize)
    {
        ItemId = itemId;
        CurrentStock = currentStock;
        ForecastedDemand = forecastedDemand;
        ReorderCostPerUnit = reorderCostPerUnit;
        BatchSize = batchSize;
    }

    public int CalculateUnitsToOrder()
    {
        // Calculate the required units to meet the forecasted demand
        int requiredUnits = ForecastedDemand - CurrentStock;

        // If current stock is sufficient, no need to reorder
        if (requiredUnits <= 0)
        {
            return 0;
        }

        // Calculate the number of batches needed
        int batchesNeeded = (requiredUnits + BatchSize - 1) / BatchSize;

        // Calculate the total units to order
        int unitsToOrder = batchesNeeded * BatchSize;

        return unitsToOrder;
    }
}

class Program
{
    static List<(int, int)> GenerateReorderingPlan(List<InventoryItem> inventoryItems)
    {
        List<(int, int)> reorderingPlan = new List<(int, int)>();

        foreach (var item in inventoryItems)
        {
            int unitsToOrder = item.CalculateUnitsToOrder();
            if (unitsToOrder > 0)
            {
                reorderingPlan.Add((item.ItemId, unitsToOrder));
            }
        }

        return reorderingPlan;
    }

    static void Main(string[] args)
    {
        // Sample Test Data
        List<InventoryItem> inventoryItems = new List<InventoryItem>
        {
            new InventoryItem(itemId: 1, currentStock: 50, forecastedDemand: 100, reorderCostPerUnit: 10, batchSize: 20),
            new InventoryItem(itemId: 2, currentStock: 30, forecastedDemand: 60, reorderCostPerUnit: 5, batchSize: 15),
            new InventoryItem(itemId: 3, currentStock: 80, forecastedDemand: 70, reorderCostPerUnit: 8, batchSize: 10),
            new InventoryItem(itemId: 4, currentStock: 10, forecastedDemand: 50, reorderCostPerUnit: 12, batchSize: 25)
        };

        // Generate the reordering plan
        var reorderingPlan = GenerateReorderingPlan(inventoryItems);

        // Output the reordering plan
        Console.WriteLine("Reordering Plan:");
        foreach (var (itemId, unitsToOrder) in reorderingPlan)
        {
            Console.WriteLine($"Item ID: {itemId}, Units to Order: {unitsToOrder}");
        }
    }
}
