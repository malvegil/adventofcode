let fs = require("fs");
let text =
  fs.readFileSync("./day01input.txt", "utf-8")
    .split('\n')
    .map(Number)
    .sort();

// Part 1
let left = 0;
let right = text.length - 1;

while (left < right) {
  let sum = text[right] + text[left];
  if (sum == 2020) {
    console.log(text[right] * text[left]);
    break;
  }

  if (sum > 2020)
    right -= 1;
  else
    left += 1;
}

// Part 2
for (var i = 0; i < text.length - 2; i++) {
  let left = i + 1;
  let right = text.length - 1;
  let found = false;
  while (left < right) {
    sum = text[i] + text[right] + text[left];
    if (sum == 2020) {
      console.log(text[i] * text[right] * text[left]);
      found = true;
      break;
    }
    if (found)
      break;
    if (sum > 2020)
      right -= 1;
    else if (sum < 2020)
      left += 1;
  }
}