using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private const int cap = 5;
        private RobotManager robotManager;
        private const string name = "Robo";
        private const int maxBattery = 100;
        private const  int battery = maxBattery;
        private Robot robot = new Robot(name,maxBattery);
        private Robot rogo = new Robot("rogo", 100);
        private List<Robot> robots;
        

        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(cap);
            this.robots = new List<Robot>();
        }

        [Test]
        public void IF_CONSTRUCTOR_WORKS_CORECTLY()
        {
            string example = "Robo";
            int maxBattery = 100;
            int battery  = maxBattery;
            
            Robot robot = new Robot(example,battery);
            
            Assert.AreEqual(example, robot.Name);
            Assert.AreEqual(battery, robot.Battery);
        }

        [Test]
        public void IF_ROBOTMANAGER_WORKS_CORRECTLY()
        {
            int expected = 5;
            
            Assert.AreEqual(expected,robotManager.Capacity);
        }

        [Test]
        public void IF_ROBOTMANAGER_THROWS_ARGUMENT_EXCEPTION()
        {
            Assert.Throws<ArgumentException>((() => this.robotManager = new RobotManager(-1) ));
        }

        [Test]
        public void IF_COUNT_WORKS_CORECTRLY()
        {
            var expectedCout = 0;
            Assert.AreEqual(expectedCout,this.robotManager.Count);
        }

        [Test]
        public void IF_ROBOT_WITH_NULL_THROWS_EXEPTION()
        {
            
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(string.Empty,"job",maxBattery));
        }

        [Test]
        public void IF_ROBOT_WITH_LITTLE_BATTERY_THROWS_EXCEPTION()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(name, "job", 103));
        }

        [Test]
        public void IF_ROBOT_TO_REMOVE_IS_NULL_THORWS_EXCEPTION()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove(string.Empty));
        }

        [Test]
        public void IF_ROBOT_TO_REMOVE_RETURNS_CORECT_RESULT()
        {
           robots.Add(robot);
           robots.Add(rogo);
           robots.Remove(robot);
           Assert.AreEqual(1, robots.Count);
        }

        [Test]
        public void IF_ADD_METHOD_THROWS_EXCEPTION_SAME_ROBOT()
        {
            Robot pesho = new Robot("Pesho", 23);
           robots.Add(pesho);
           robots.Add(pesho);
            Assert.Throws<InvalidOperationException>(() => robots.Any(r =>r.Name == "Pesho"));
        }

        [Test]
        public void CAPACITY_IS_FULL()
        {
            robots.Add(robot);
            robots.Add(rogo);
            Assert.Throws<InvalidOperationException>(() => robots.Capacity = robots.Count);
        }

        // [Test]
        // public void IF_BATTERY_IS_CHARGING()
        // {
        //     var exprected = 100;
        //     var gosho = robot.Name;
        //     
        //     Assert.AreEqual(exprected);
        //     
        // }
    }
}
