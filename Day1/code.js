const fs = require("fs");

fs.readFile("Day1/data.txt", (err, data) => {
  if (err) throw err;

  console.log(data.toString());
});
