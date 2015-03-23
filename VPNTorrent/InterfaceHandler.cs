﻿using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Controls;

namespace VPNTorrent
{
    class InterfaceHandler
    {
        Dictionary<String, NetworkInterface> m_dicAdapters = new Dictionary<String, NetworkInterface>();

        ScrollViewer m_viewForLogging = null;
        ConfigHandler m_config = null;

        public InterfaceHandler(ScrollViewer viewForLogging, ConfigHandler config) {
            m_viewForLogging = viewForLogging;
            m_config = config;
        }

        public List<NetworkInterface> getActiveNetworkInterfaces() {
            Helper.doLog(m_viewForLogging, "getNetworkInterfaces ", m_config.DebugMode, m_config.ConsoleMaxSize);

            m_dicAdapters.Clear();

            List<NetworkInterface> listInterfaces = new List<NetworkInterface>();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters) {

                if (adapter.Id == null) {
                    continue;
                }

                //keep the dictionary updated
                m_dicAdapters[adapter.Id] = adapter;

                if (adapter.OperationalStatus == OperationalStatus.Up &&
                    adapter.GetIPProperties() != null && adapter.Description != null && adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback) {
                    //String strAdapter = adapter.Description + "#" + adapter.Id + "#" + adapterProperties.UnicastAddresses[0].Address;
                    Helper.doLog(m_viewForLogging, "getNetworkInterfaces " + adapter.Id, m_config.DebugMode, m_config.ConsoleMaxSize);
                    listInterfaces.Add(adapter);
                }
            }

            return listInterfaces;
        }

        public NetworkInterface getNetworkDetails(String strID) {
            Helper.doLog(m_viewForLogging, "getNetworkDetails " + strID, m_config.DebugMode, m_config.ConsoleMaxSize);

            if (strID != null && m_dicAdapters.ContainsKey(strID)) {
                return m_dicAdapters[strID];
            } else {
                return null;
            }
        }

        public Boolean isNetworkConnected(NetworkInterface net) {
            Boolean bReturn = false;
            if (net != null && net.OperationalStatus == OperationalStatus.Up && net.GetIPProperties() != null && net.Description != null && net.NetworkInterfaceType != NetworkInterfaceType.Loopback) {
                bReturn =  true;
            }

            Helper.doLog(m_viewForLogging, "isNetworkConnected " + net.Id + " = " + bReturn, m_config.DebugMode, m_config.ConsoleMaxSize);

            return bReturn;
        }

        public String findSelectedInterface(String strSelection) {
            Helper.doLog(m_viewForLogging, "findSelectedInterface " + strSelection, m_config.DebugMode, m_config.ConsoleMaxSize);

            foreach (KeyValuePair<String, NetworkInterface> entry in m_dicAdapters) {
                // do something with entry.Value or entry.Key
                if (strSelection.StartsWith(entry.Value.Description)) {
                    Helper.doLog(m_viewForLogging, "findSelectedInterface found " + entry.Key + " " + entry.Value.Description, m_config.DebugMode, m_config.ConsoleMaxSize);
                    return entry.Key;
                }
            }

            return null;
        }
    }
}
