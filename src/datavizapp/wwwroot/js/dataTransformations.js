function dataTransform(data) {

    transformedData = [];

    for (var key in data) {
        transformedData.push({ "Label": key, "Value": data[key] });
    }

    return transformedData;
}