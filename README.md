# 🌍 World Simulator – Exercises

A **C# practice project** designed to build a simulated society of humans with evolving attributes, relationships, and behaviors.  
The project is divided into three levels: **Beginner**, **Intermediate**, and **Advanced**.

---

## 🧩 Beginner Level (Basic C# & Object Manipulation)

1. **Print all humans in the society**  
   Loop through the `Society` list and print each human’s name, gender, and age using the `ToString()` method.

2. **Show total population**  
   Display the static property `Human.Population` to show how many humans exist.

3. **List all female humans**  
   Use LINQ or a `foreach` loop to show only the females.

4. **List all males older than 20**  
   Filter the `Society` list by both gender and age.

5. **Count Adam and Eve’s children**  
   Count how many humans in `Society` have `"Garden of Eden"` as `HomeLocation` and an age less than 20.

6. **Print the oldest human**  
   Find and print the human with the highest `Age`.

7. **Make all humans older**  
   Use a `foreach` loop to call `.GetOlder()` for everyone in the list.

8. **Print average age**  
   Calculate the average age of all humans using LINQ:  
   ```csharp
   Society.Average(h => h.Age);
   ```

---

## ⚙️ Intermediate Level (Methods, Logic, and LINQ)

9. **Add a Die() method**  
   - When called, set `IsAlive = false`.  
   - Decrease the population counter.  
   - Try “killing” one human and verify that the population decreases.

10. **Add an Eat() method**  
    - If `Hunger > 0`, reduce it by a random amount.  
    - Slightly increase `EnergyLevel` and `Happiness`.

11. **Add a Sleep() method**  
    - Restore `EnergyLevel` and `SleepQuality`, but only if the human is alive.

12. **Add a Work() method**  
    - Increases `Wealth`.  
    - Decreases `EnergyLevel`.  
    - Increases `StressLevel`.

13. **Add a Rest() method**  
    - Opposite of `Work()`: reduces stress and restores happiness and energy.

14. **Add a Speak() method**  
    - Print `"Name says: Hello!"`  
    - Later, extend it to allow one human to speak to another.

15. **Add a PrintSummary() method**  
    - Nicely format and print all key stats (Age, Gender, Health, Energy, Happiness).

16. **Sort humans by age**  
    - Use LINQ or `List.Sort()` to order society by `Age` and print the results.

17. **Create random humans**  
    - Write a helper function that creates humans with random names, genders, and home locations.

18. **Group humans by gender**  
    - Use LINQ:  
      ```csharp
      var groups = Society.GroupBy(h => h.Gender);
      ```  
    - Then print each group and its members.

---

## 🧠 Advanced Level (Simulation & Relationships)

19. **Track parent–child relationships**  
    - Add properties `Mother` and `Father` to `Human`.  
    - Update `MakeChild()` so it sets those references.

20. **Display family tree**  
    - For a given human, print their parents and siblings.

21. **Simulate yearly aging**  
    - Create a `SimulateYear()` method that:  
      - Calls `GetOlder()`  
      - Randomly adjusts `Health` and `Happiness`  
      - Optionally adds or removes a few humans

22. **Add education**  
    - Create a method `GoToSchool()` that increases `Intelligence` and adds `"Education"` to `Skills`.

23. **Add a skill-learning system**  
    - Implement `LearnSkill(string skill)` which adds the skill to the list and slightly improves `Creativity`.

24. **Add wealth transfer (inheritance)**  
    - When a human dies, transfer their `Wealth` evenly to all living children.

25. **Simulate society over multiple generations**  
    - In a loop, let pairs of living adults create children until the population reaches a set limit.  
    - Print stats like average age, happiness, and population size.

26. **Find the happiest human**  
    - Use LINQ to get the human with the highest `Happiness`.

27. **Add a search function**  
    - Create a static method `FindByName(string name)` that searches the list of humans and returns the first match.

28. **Add a friendship system**  
    - Implement `AddFriend(Human person)` to add another human to `SocialConnections`.

29. **Add population statistics**  
    - Calculate average health, happiness, and wealth across the society.

30. **Random events system**  
    - Every “year,” simulate random events (e.g., illness, discovery, good harvest) that change attributes of random humans.

---
