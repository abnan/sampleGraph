# Assessment Submission

- **Time complexity**: O(n^2) Each user is compared against every other user to compute their mutual distance and then the furthest user is computed. This results in a complexity of O(n^2). My implementation could be made a bit more efficient by updating both users when the furthest user from an user is found. This can be achieved in O(nlogn) by using the rotating calipers method (https://stackoverflow.com/a/27193106).
- **Space complexity**: Space complexity is O(1), since we can just calculate distances and store the largest one and the two users when we are doing our n^2 computation.

- With more time, a proper MVC/MVVM framework could be used for data binding to controls rather than using a label's text field as I did.
- For configuring the refresh time-interval, please update the *timerInterval* key in App.config. 5000 = 5 seconds
