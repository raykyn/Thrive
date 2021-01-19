﻿using System.Collections.Generic;
using Godot;

/// <summary>
///   Dataset to be visualized on the line chart. Contains series of data points.
/// </summary>
public class LineChartData
{
    private Color dataColour;
    private bool draw = true;

    // ReSharper disable once CollectionNeverUpdated.Global
    public List<DataPoint> DataPoints { get; set; } = new List<DataPoint>();

    /// <summary>
    ///   The icon on the chart legend
    /// </summary>
    public Texture IconTexture { get; set; }

    public float LineWidth { get; set; } = 1.15f;

    /// <summary>
    ///   Used to differentiate the data set's visual by color
    /// </summary>
    public Color DataColour
    {
        get => dataColour;
        set
        {
            dataColour = value;

            foreach (var point in DataPoints)
                point.MarkerColour = dataColour;
        }
    }

    /// <summary>
    ///   If this is true, visuals will be drawn (e.g lines, markers)
    /// </summary>
    public bool Draw
    {
        get => draw;
        set
        {
            draw = value;

            foreach (var point in DataPoints)
                point.Visible = value;
        }
    }

    /// <summary>
    ///   Frees and removes all data point from this dataset. Use this rather than
    ///   DataPoints.Clear to avoid orphaned nodes.
    /// </summary>
    public void ClearPoints()
    {
        foreach (var point in DataPoints.ToArray())
        {
            point.Free();
            DataPoints.Remove(point);
        }
    }
}
