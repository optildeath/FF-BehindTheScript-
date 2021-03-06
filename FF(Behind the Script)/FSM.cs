﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADGP_125
{

    public class FinistateStatMachine<T>
    {
        // Sets transtions between my 
        public class Transition
        {
            public T _from, _to;
            public Transition(T from, T to)
            {
                _from = from;
                _to = to;

            }
        }

        T _currentState;
        Dictionary<T, List<Transition>> _transtionTable;
        List<T> m_States;

        //List<Enum> validTrans;

        /// <summary>
        /// Constructer for the FSM
        /// </summary>  
        ///       /// Takes in the first Enum 
        /// <param FininitStateMachine ="intial"> Takes  in the first stat </para>
        public FinistateStatMachine(T intial)
        {
            m_States = new List<T>();
            //validTrans = new List<Enum>();
            _transtionTable = new Dictionary<T, List<Transition>>();
            _currentState = intial;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AddStat(T state)
        {
            
            if (!m_States.Contains(state)) { // List<>.Contains ~ Lets me know if the elements in the list(returning a bool)
                m_States.Add(state);
                _transtionTable.Add(state, new List<Transition>());
                return false;
            }
            else {
                return true;
            }
        }

        /// <summary>
        ///  Prints States Stat To console
        /// </summary>
        /// <StatesInfor()>
        /// Prints out the listed sort of Enums and its enumaration 
        /// Prints out the conditions of the transitions 
        /// </StatesInfor>
        public void StatInfo()
        {
            Console.WriteLine("Finite Stat Machine is comprised of...");
            int count = 0; // Records the ammount of States that have been added the List<Enum>
            foreach (T s in m_States)
            {
                Console.WriteLine("Stat " + count + ": " + s.ToString());
                ++count;

            }
            Console.WriteLine("Current Stat(s) is: " + _currentState.ToString());

        }

        /// <summary>
        /// Qeues in the set of transitions
        /// </summary>
        /// <AddTransition(Enum from, Enum to)>
        /// AddTRansition takes in two arguments 
        /// thsi 
        /// </AddTransition>
        public bool AddTransiton(T from, T to)
        {

            Transition _t = new Transition(from, to);

            if (_transtionTable.ContainsKey(from))
            {
                _transtionTable[_currentState].Add(_t);
                return true;
            }
            return false;
        }

        /// <summary> 
        /// Makes the Transion from the queued states
        /// </summary>
        /// <TranstitionFromStates(Enum trans)>
        /// This Sets  my States and makes sure of there possibale transitions 
        /// TrnsitonFromStates takes in one argument 
        /// A new Tempuary Transition<Object>(temp_Trans) is created 
        /// 
        /// A new Tempuary Dictanery<Enum,List<Transition<Object>>(temp_Dictionary) is created 
        /// Creats a Temporary Dictionary<Enum, List<TRanstion>>
        /// 
        /// if currentState value returns a (0) there at there init state
        /// transtion from that enumarate value can transiton to the next state. 
        /// no transtions can happen over that value or transition to that same value 
        /// 
        /// if currentState enumarte value retuns a (1) there at the next state 
        /// From this state the user can transition to thhe next transition 
        /// They can not transition over from that state or revert over to the init stat
        /// 
        /// if currentState value returns any other value pass the _currentState value of (1) 
        /// Transition to and fom that state can happen 
        /// Transitions form that state to the _currnetState (0) can not happen 
        /// </TranstitionFromStates>
        //public void TransitionsFromStates()
        //{


        //    foreach (T e in m_transtionTable.Keys)
        //    {
        //        Transition temp_Trans = new Transition(m_currentState, e);
        //        if (AddTransiton(m_currentState, e))
        //        {
        //            if (AddStat(e))
        //            {
        //                switch (m_currentState.GetHashCode())
        //                {
        //                    case 0:
        //                        if (e.GetHashCode() > 1 || e.GetHashCode() == m_currentState.GetHashCode())
        //                            Console.WriteLine(m_currentState + " can not make this transition to " + e);
        //                        else
        //                        {
        //                            Console.WriteLine(m_currentState + " -> " + e);
        //                            m_transtionTable[m_currentState].Add(temp_Trans);
        //                            m_currentState = e;
        //                        }
        //                        break;

        //                    case 1:
        //                        if (e.GetHashCode() <= 0 || (1 + m_currentState.GetHashCode()) < e.GetHashCode() 
        //                            || e.GetHashCode() == m_currentState.GetHashCode())
        //                            Console.WriteLine(m_currentState + " can not make this transtion to " + e);
        //                        else
        //                        {
        //                            Console.WriteLine(m_currentState + " -> " + e);
        //                            m_transtionTable[e].Add(temp_Trans);
        //                            m_currentState = e;
        //                        }
        //                        break;
        //                    default:
        //                        if (e.GetHashCode() <= 0 || e.GetHashCode() == m_currentState.GetHashCode())
        //                            Console.WriteLine(m_currentState + " can not make this transtion to " + e);
        //                        else
        //                        {
        //                            Console.WriteLine(m_currentState + " -> " + e);
        //                            m_transtionTable[e].Add(temp_Trans);
        //                            m_currentState = e;
        //                        }
        //                        break;
                                
        //                }
                        
        //            }
                   
        //            else { Console.WriteLine("Cant transition to a none exiatent state "); break; }
        //        }
        //        else { Console.WriteLine("No States have been added "); break; }
        //    }
        //}

        /// <summary>
        /// you do not care about changestate("notthecurrentstate")
        /// </summary>
        /// <param name="To"></param>
        public void ChangeState(T To)
        {
            List<Transition> validTransitions = _transtionTable[_currentState];
            foreach (Transition t in validTransitions)
            {
                //if To is the name of where you want to go
                if(To.Equals(t._to))
                    _currentState = t._to;
            }

        }
        public T CurrentStat { get { return _currentState; } }
    }
}       
            
       
