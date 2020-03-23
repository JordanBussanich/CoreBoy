using System;
using System.Collections.Generic;

namespace CoreBoy
{
    public partial class CPU
    {
        private class Ops
        {
            private CPU _cpu;

            public Ops(CPU cpu)
            {
                _cpu = cpu;
            }

            private enum Registers16Bit
            {
                AF,
                BC,
                DE,
                HL,
                SP
            }

            // 0x00 - NOP
            public Operation NOP() => new Operation(() =>
            {
                _cpu.Registers.PC.Value++;
            }, "NOP", 4);

            // 0x01 - LD BC,nn
            public Operation LD_BC_nn() => new Operation(Get16BitLdAction(Registers16Bit.BC), "LD_BC_nn", 12);

            // 0x11 - LD DE,nn
            public Operation LD_DE_nn() => new Operation(Get16BitLdAction(Registers16Bit.DE), "LD_DE_nn", 12);

            // 0x21 - LD HL,nn
            public Operation LD_HL_nn() => new Operation(Get16BitLdAction(Registers16Bit.HL), "LD_HL_nn", 12);

            // 0x31 - LD SP,nn
            public Operation LD_SP_nn() => new Operation(Get16BitLdAction(Registers16Bit.SP), "LD_SP_nn", 12);

            // 0xA8 - XOR B
            public Operation XOR_B() => new Operation(GetXorAction(_cpu.Registers.B), "XOR B", 4);

            // 0xA9 - XOR C
            public Operation XOR_C() => new Operation(GetXorAction(_cpu.Registers.C), "XOR C", 4);

            // 0xAA - XOR D
            public Operation XOR_D() => new Operation(GetXorAction(_cpu.Registers.D), "XOR D", 4);

            // 0xAB - XOR E
            public Operation XOR_E() => new Operation(GetXorAction(_cpu.Registers.E), "XOR E", 4);

            // 0xAC - XOR H
            public Operation XOR_H() => new Operation(GetXorAction(_cpu.Registers.H), "XOR H", 4);

            // 0xAC - XOR L
            public Operation XOR_L() => new Operation(GetXorAction(_cpu.Registers.L), "XOR L", 4);

            // 0xAF - XOR A
            public Operation XOR_A() => new Operation(GetXorAction(_cpu.Registers.A), "XOR A", 4);



            // 0xC3 - JP, nn
            public Operation JP_nn() => new Operation(() =>
            {
                ushort leastSignificanByte = _cpu.Memory[_cpu.Registers.PC.Value + 0x1];
                ushort mostSignificantByte = _cpu.Memory[_cpu.Registers.PC.Value + 0x2];

                ushort newAddress = (ushort)((ushort)(mostSignificantByte << 8) | leastSignificanByte);

                _cpu.Registers.PC.Value = newAddress;
            }, "JP, nn", 12);
        
            private Action GetXorAction(Register8Bit parameterRegister) => (() =>
            {
                byte result = (byte)(parameterRegister.Value ^ _cpu.Registers.A.Value);
                
                _cpu.Registers.A.Value = result;

                if (result == 0)
                {
                    _cpu.Registers.ZZeroFlag = true;
                }
                else
                {
                    _cpu.Registers.ZZeroFlag = false;
                }

                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = false;

                _cpu.Registers.PC.Value++;
            });

            private Action Get16BitLdAction(Registers16Bit destinationRegister) => (() =>
            {
                byte firstByte = _cpu.Memory[_cpu.Registers.PC.Value + 0x1];
                byte secondByte = _cpu.Memory[_cpu.Registers.PC.Value + 0x2];
                
                switch (destinationRegister)
                {
                    case Registers16Bit.BC:
                        _cpu.Registers.B.Value = firstByte;
                        _cpu.Registers.C.Value = secondByte;
                        break;
                    case Registers16Bit.DE:
                        _cpu.Registers.D.Value = firstByte;
                        _cpu.Registers.E.Value = secondByte;
                        break;
                    case Registers16Bit.HL:
                        _cpu.Registers.H.Value = firstByte;
                        _cpu.Registers.L.Value = secondByte;
                        break;
                    case Registers16Bit.SP:
                        ushort combined = (ushort)((ushort)(firstByte << 8) | secondByte);
                        _cpu.Registers.SP.Value = combined;
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                _cpu.Registers.PC.Value += 0x3;
            });
        }
    }
}