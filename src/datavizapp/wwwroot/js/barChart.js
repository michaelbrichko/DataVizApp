function drawBarchart(data, chartContainerId, yAxisLabel, showBarLabelsOnTooltip) {

    // Set the dimensions of the canvas
    var margin = { top: 40, right: 20, bottom: 130, left: 40 };
    var height = 500 - margin.top - margin.bottom;
    var width = 900 - margin.left - margin.right;

    // Set the ranges
    var x = d3.scale.ordinal().rangeRoundBands([0, width], .05);
    var y = d3.scale.linear().range([height, 0]);

    // Define the axis
    var xAxis = d3.svg.axis().scale(x).orient("bottom");
    var yAxis = d3.svg.axis().scale(y).orient("left").ticks(10);

    // Add the SVG element
    var svg = d3.select(chartContainerId)
        .append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform",
            "translate(" + margin.left + "," + margin.top + ")");

    x.domain(data.map(function (d) { return d.Label; }));
    y.domain([0, d3.max(data, function (d) { return d.Value; })]);

    // Add axis
    if (showBarLabelsOnTooltip) {
        xAxis = xAxis.tickValues([]);
    }

    svg.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + height + ")")
        .call(xAxis)
        .selectAll("text")
        .style("text-anchor", "end")
        .attr("dx", "-.8em")
        .attr("dy", "-.55em")
        .attr("transform", "rotate(-90)");

    svg.append("g")
        .attr("class", "y axis")
        .call(yAxis)
        .append("text")
        .attr("transform", "rotate(-90)")
        .attr("y", 5)
        .attr("dy", ".71em")
        .style("text-anchor", "end")
        .text(yAxisLabel);

    // Add tooltip
    var tip = d3.tip()
        .attr('class', 'd3-tip')
        .offset([-10, 0])
        .html(function (d) {
            return "<span>" + d.Value + (showBarLabelsOnTooltip == true ? "  -  " + d.Label : "") + "</span>";
        });

    svg.call(tip);

    // Add bar chart
    svg.selectAll("bar")
        .data(data)
        .enter()
        .append("rect")
        .attr("class", "bar")
        .attr("x", function (d) { return x(d.Label); })
        .attr("width", x.rangeBand())
        .attr("y", function (d) { return y(d.Value); })
        .attr("height", function (d) { return height - y(d.Value); })
        .on('mouseover', tip.show)
        .on('mouseout', tip.hide);
}