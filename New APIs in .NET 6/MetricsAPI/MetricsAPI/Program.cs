// https://twitter.com/okyrylchuk/status/1453101186622578693

using Microsoft.AspNetCore.Builder;
using System;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Create Meter
var meter = new Meter("MetricsApp", "v1.0");
// Create counter
Counter<int> counter = meter.CreateCounter<int>("Requests");

app.Use((context, next) =>
{
        // Record the value of measurement
        counter.Add(1);
    return next(context);
});

app.MapGet("/", () => "Hello World");

StartMeterListener();

app.Run();

// Create and start Meter Listener
void StartMeterListener()
{
    var listener = new MeterListener();
    listener.InstrumentPublished = (instrument, meterListener) =>
    {
        if (instrument.Name == "Requests" && instrument.Meter.Name == "MetricsApp")
        {
            // Start listening to a specific measurement recording
            meterListener.EnableMeasurementEvents(instrument, null);
        }
    };

    listener.SetMeasurementEventCallback<int>((instrument, measurement, tags, state) =>
    {
        Console.WriteLine($"Instrument {instrument.Name} has recorded the measurement: {measurement}");
    });

    listener.Start();
}


