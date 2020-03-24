using System;
using System.Collections.Generic;

namespace CoreBoy
{
    public partial class CPU
    {
        private void InitialiseOperations()
        {
            var ops = new Ops(this);

            // 0x00 - NOP
            Operations.Add(0x00, ops.NOP());      

            // 0x01 - LD BC,nn
            Operations.Add(0x01, ops.LD_16(Register16BitNames.BC));

            // 0x02 - LD (BC), A
            Operations.Add(0x02, ops.LD_8(Register8BitNames.A, Register16BitNames.BC));

            // 0x04 - INC B
            Operations.Add(0x04, ops.INC_8(Register8BitNames.B));

            // 0x05 - DEC B
            Operations.Add(0x05, ops.DEC_8(Register8BitNames.B));

            // 0x06 - LD B,n
            Operations.Add(0x06, ops.LD_8(Register8BitNames.B));

            // 0x07 RLCA
            Operations.Add(0x07, ops.RLCA());

            // 0x08 LD (nn), SP
            Operations.Add(0x08, ops.LD_16_SP());

            // 0x09 - ADD HL,BC
            Operations.Add(0x09, ops.ADD_16(Register16BitNames.BC));

            // 0x02 - LD (DE), A
            Operations.Add(0x12, ops.LD_8(Register8BitNames.A, Register16BitNames.DE));

            // 0x0C - INC C
            Operations.Add(0x0C, ops.INC_8(Register8BitNames.C));

            // 0x0D - DEC C
            Operations.Add(0x0D, ops.DEC_8(Register8BitNames.C));

            // 0x0E - LD C,n
            Operations.Add(0x0E, ops.LD_8(Register8BitNames.C));

            // 0x11 - LD DE,nn
            Operations.Add(0x11, ops.LD_16(Register16BitNames.DE));

            // 0x14 - INC D
            Operations.Add(0x14, ops.INC_8(Register8BitNames.D));

            // 0x15 - DEC D
            Operations.Add(0x15, ops.DEC_8(Register8BitNames.D));

            // 0x16 - LD D,n
            Operations.Add(0x16, ops.LD_8(Register8BitNames.D));

            // 0x19 - ADD HL,DE
            Operations.Add(0x19, ops.ADD_16(Register16BitNames.DE));

            // 0x1C - INC E
            Operations.Add(0x1C, ops.INC_8(Register8BitNames.E));

            // 0x1D - DEC E
            Operations.Add(0x1D, ops.DEC_8(Register8BitNames.E));

            // 0x1E - LD E,n
            Operations.Add(0x1E, ops.LD_8(Register8BitNames.E));

            // 0x1F - RRA
            Operations.Add(0x1F, ops.RRA());

            // 0x20 - JR NZ,n
            Operations.Add(0x20, ops.JR(JRFlags.NZ));

            // 0x21 - LD HL,nn
            Operations.Add(0x21, ops.LD_16(Register16BitNames.HL));

            // 0x24 - INC H
            Operations.Add(0x24, ops.INC_8(Register8BitNames.H));

            // 0x25 - DEC H
            Operations.Add(0x25, ops.DEC_8(Register8BitNames.H));

            // 0x26 - LD H,n
            Operations.Add(0x26, ops.LD_8(Register8BitNames.H));

            // 0x28 - JR Z,n
            Operations.Add(0x28, ops.JR(JRFlags.Z));

            // 0x29 - ADD HL,HL
            Operations.Add(0x29, ops.ADD_16(Register16BitNames.HL));

            // 0x2C - INC L
            Operations.Add(0x2C, ops.INC_8(Register8BitNames.L));

            // 0x2D - DEC L
            Operations.Add(0x2D, ops.DEC_8(Register8BitNames.L));

            // 0x2E - LD H,n
            Operations.Add(0x2E, ops.LD_8(Register8BitNames.L));

            // 0x30 - JR NC,n
            Operations.Add(0x30, ops.JR(JRFlags.NC));

            // 0x31 - LD SP,nn
            Operations.Add(0x31, ops.LD_16(Register16BitNames.SP));

            // 0x32 - LDD (HL),A
            Operations.Add(0x32, ops.LDD(Register8BitNames.A, Register16BitNames.HL));

            // 0x35 - DEC A
            Operations.Add(0x35, ops.DEC_8(Register8BitNames.A));

            // 0x38 - JR C,n
            Operations.Add(0x38, ops.JR(JRFlags.C));

            // 0x39 - ADD HL,SP
            Operations.Add(0x39, ops.ADD_16(Register16BitNames.SP));

            // 0x3C - INC A
            Operations.Add(0x3C, ops.INC_8(Register8BitNames.A));

            // 0x77 - LD (HL), A
            Operations.Add(0x77, ops.LD_8(Register8BitNames.A, Register16BitNames.HL));

            // 0x78 - LD A, B
            Operations.Add(0x78, ops.LD_8(Register8BitNames.B, Register8BitNames.A));

            // 0x79 - LD A, C
            Operations.Add(0x79, ops.LD_8(Register8BitNames.C, Register8BitNames.A));

            // 0x7A - LD A, D
            Operations.Add(0x7A, ops.LD_8(Register8BitNames.D, Register8BitNames.A));

            // 0x7B - LD A, E
            Operations.Add(0x7B, ops.LD_8(Register8BitNames.E, Register8BitNames.A));

            // 0x7C - LD A, H
            Operations.Add(0x7C, ops.LD_8(Register8BitNames.H, Register8BitNames.A));

            // 0x7D - LD A, L
            Operations.Add(0x7D, ops.LD_8(Register8BitNames.L, Register8BitNames.A));

            // 0x7F - LD A, A
            Operations.Add(0x7F, ops.LD_8(Register8BitNames.A, Register8BitNames.A));

            // 0xA8 - XOR B
            Operations.Add(0xA8, ops.XOR_8(Register8BitNames.B));

            // 0xA9 - XOR C
            Operations.Add(0xA9, ops.XOR_8(Register8BitNames.C));

            // 0xAA - XOR D
            Operations.Add(0xAA, ops.XOR_8(Register8BitNames.D));

            // 0xAB - XOR E
            Operations.Add(0xAB, ops.XOR_8(Register8BitNames.E));

            // 0xAC - XOR H
            Operations.Add(0xAC, ops.XOR_8(Register8BitNames.H));

            // 0xAD - XOR L
            Operations.Add(0xAD, ops.XOR_8(Register8BitNames.L));

            // 0xAF - XOR A
            Operations.Add(0xAF, ops.XOR_8(Register8BitNames.A));

            // 0xB0 - OR B
            Operations.Add(0xB0, ops.OR_8(Register8BitNames.B));

            // 0xB1 - OR C
            Operations.Add(0xB1, ops.OR_8(Register8BitNames.C));

            // 0xB2 - OR D
            Operations.Add(0xB2, ops.OR_8(Register8BitNames.D));

            // 0xB3 - OR E
            Operations.Add(0xB3, ops.OR_8(Register8BitNames.E));

            // 0xB4 - OR H
            Operations.Add(0xB4, ops.OR_8(Register8BitNames.H));

            // 0xB5 - OR L
            Operations.Add(0xB5, ops.OR_8(Register8BitNames.L));

            // 0xB7 - OR A
            Operations.Add(0xB7, ops.OR_8(Register8BitNames.A));

            // 0xB8 - CP B
            Operations.Add(0xB8, ops.CP(Register8BitNames.B));

            // 0xB9 - CP C
            Operations.Add(0xB9, ops.CP(Register8BitNames.C));

            // 0xBA - CP D
            Operations.Add(0xBA, ops.CP(Register8BitNames.D));

            // 0xBB - CP E
            Operations.Add(0xBB, ops.CP(Register8BitNames.E));
            
            // 0xBC - CP H
            Operations.Add(0xBC, ops.CP(Register8BitNames.H));

            // 0xBD - CP L
            Operations.Add(0xBD, ops.CP(Register8BitNames.L));

            // 0xBF - CP A
            Operations.Add(0xBF, ops.CP(Register8BitNames.A));

            // 0xC2 - JP NZ,nn
            Operations.Add(0xC2, ops.JP_cc_nn(JRFlags.NZ));

            // 0xC3 - JP, nn
            Operations.Add(0xC3, ops.JP_nn());

            // 0xCA - JP Z,nn
            Operations.Add(0xCA, ops.JP_cc_nn(JRFlags.Z));

            // 0xD2 - JP NC,nn
            Operations.Add(0xD2, ops.JP_cc_nn(JRFlags.NC));

            // 0xDA - JP C,nn
            Operations.Add(0xDA, ops.JP_cc_nn(JRFlags.C));
        }

        public enum JRFlags
        {
            NZ,
            Z,
            NC,
            C
        }

        private class Ops
        {
            private CPU _cpu;

            public Ops(CPU cpu)
            {
                _cpu = cpu;
            }

            public Operation NOP() => new Operation(() =>
            {
                Console.WriteLine("NOP");
            }, "NOP", 4, 1);

            public Operation LD_16(Register16BitNames register) => new Operation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                ushort lsByte = _cpu.Memory[currentPC + 0x1];
                ushort msByte = _cpu.Memory[currentPC + 0x2];

                ushort newValue = (ushort)((msByte << 8) | lsByte);

                Console.WriteLine($"LD {register.ToString()}, LS Byte: 0x{lsByte.ToString("X2")}, MS Byte: 0x{msByte.ToString("X2")}, Value: 0x{newValue.ToString("X4")}");

                _cpu.Registers.SetRegisterValue(register, newValue);

            }, $"LD {register.ToString()}, nn", 12, 3);

            public Operation LD_16_SP() => new Operation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort currentSP = _cpu.Registers.GetRegisterValue(Register16BitNames.SP);

                ushort addressLSB = _cpu.Memory[currentPC + 0x1];
                ushort addressMSB = _cpu.Memory[currentPC + 0x2];

                ushort address = (ushort)((addressMSB << 8) | addressLSB);

                Console.WriteLine($"LD (nn), SP, (nn)LS Byte: 0x{addressLSB.ToString("X2")}, (nn)MS Byte: 0x{addressMSB.ToString("X2")}, Value: 0x{address.ToString("X4")}");

                byte spLSB = (byte)((currentSP & 0b_1111_1111_0000_0000) >> 8);
                byte spMSB = (byte)(currentSP & 0b_0000_0000_1111_1111);

                _cpu.Memory[address] = spLSB;
                _cpu.Memory[address + 0x1] = spMSB;
            }, $"LD (nn), SP", 20, 3);

            public Operation LDD(Register8BitNames sourceRegister, Register16BitNames destinationRegister) => new Operation(() =>
            {               
                Console.WriteLine($"LDD {sourceRegister.ToString()}, {destinationRegister.ToString()}");
                
                ushort destinationAddress = _cpu.Registers.GetRegisterValue(destinationRegister);

                byte sourceValue = (byte)(_cpu.Registers.GetRegisterValue(sourceRegister));

                _cpu.Memory[destinationAddress] = sourceValue;

                _cpu.Registers.SetRegisterValue(destinationRegister, --destinationAddress);

            }, $"LDD {sourceRegister.ToString()}, {destinationRegister.ToString()}", 8, 1);

            public Operation LD_8(Register8BitNames register) => new Operation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);

                byte value = _cpu.Memory[currentPC + 0x1];

                Console.WriteLine($"LD {register.ToString()}, 0x{value.ToString("X2")}");

                _cpu.Registers.SetRegisterValue(register, value);
            }, $"LD {register.ToString()}, nn", 8, 2);

            public Operation LD_8(Register8BitNames source, Register8BitNames target) => new Operation(() =>
            {
                Console.WriteLine($"LD {target.ToString()}, {source.ToString()}");

                byte sourceValue = _cpu.Registers.GetRegisterValue(source);
                _cpu.Registers.SetRegisterValue(target, sourceValue);
            }, $"LD {target.ToString()}, {source.ToString()}", 4, 1);

            public Operation LD_8(Register8BitNames source, Register16BitNames target) => new Operation(() =>
            {
                Console.WriteLine($"LD {target.ToString()}, {source.ToString()}");

                byte sourceValue = _cpu.Registers.GetRegisterValue(source);
                _cpu.Registers.SetRegisterValue(target, sourceValue);
            }, $"LD {target.ToString()}, {source.ToString()}", 8, 1);

            public Operation DEC_8(Register8BitNames register) => new Operation(() =>
            {
                Console.WriteLine($"DEC {register.ToString()}");

                byte operand = _cpu.Registers.GetRegisterValue(register);
                byte result = (byte)(operand - 1);

                _cpu.Registers.SetRegisterValue(register, result);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = true;
                _cpu.Registers.HHalfCarryFlag = operand == 0b_0001_0000;

            }, $"DEC {register.ToString()}", 4, 1);

            public Operation INC_8(Register8BitNames register) => new Operation(() =>
            {
                Console.WriteLine($"INC {register.ToString()}");

                byte operand = _cpu.Registers.GetRegisterValue(register);
                byte result = (byte)(operand + 1);

                _cpu.Registers.SetRegisterValue(register, result);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = result == 0b_0001_0000;

            }, $"INC {register.ToString()}", 4, 1);

            public Operation OR_8(Register8BitNames register) => new Operation(() =>
            {
                Console.WriteLine($"OR {register.ToString()}");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                byte operand = _cpu.Registers.GetRegisterValue(register);

                byte result = (byte)(currentA | operand);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = false;

            }, $"OR {register.ToString()}", 4, 1);

            public Operation JR(JRFlags flag) => new Operation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort newAddress = 0;
                bool jump = false;

                switch (flag)
                {
                    case (JRFlags.NZ):
                        if (!_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.Z):
                        if (_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.NC):
                        if (!_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.C):
                        if (_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                }

                if (jump)
                {
                    newAddress = (ushort)((sbyte)(_cpu.Memory[currentPC + 1] + 1) + currentPC + 1);
                }
                else
                {
                    newAddress = (ushort)(currentPC + 2);
                }

                Console.WriteLine($"JR {flag.ToString()}, 0x{_cpu.Memory[currentPC + 1].ToString("X2")}");

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, newAddress);

            }, $"JR {flag.ToString()}, n", 8, null);

            public Operation JP_cc_nn(JRFlags flag) => new Operation(() =>
            {
                ushort currentPC = _cpu.Registers.GetRegisterValue(Register16BitNames.PC);
                ushort newAddress = 0;
                bool jump = false;

                switch (flag)
                {
                    case (JRFlags.NZ):
                        if (!_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.Z):
                        if (_cpu.Registers.ZZeroFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.NC):
                        if (!_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                    case (JRFlags.C):
                        if (_cpu.Registers.CCarryFlag)
                        {
                            jump = true;
                        }
                        break;
                }

                if (jump)
                {
                    ushort addressLSB = _cpu.Memory[currentPC + 0x1];
                    ushort addressMSB = _cpu.Memory[currentPC + 0x2];

                    newAddress = (ushort)(addressLSB | (ushort)(addressMSB << 8));
                }
                else
                {
                    newAddress = (ushort)(currentPC + 2);
                }

                Console.WriteLine($"JP {flag.ToString()}, 0x{newAddress.ToString("X4")}");

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, newAddress);

            }, $"JP {flag.ToString()}, nn", 12, null);

            public Operation RRA() => new Operation(() =>
            {
                Console.WriteLine("RRA");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                
                byte newCarry = (byte)(currentA & 0b_0000_0001);
                byte newBit7 = (byte)((_cpu.Registers.CCarryFlag ? (byte)0x1 : (byte)0x0) << 7);

                byte newA = (byte)((byte)(currentA >> 1) | newBit7);

                _cpu.Registers.ZZeroFlag = newA == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = newCarry == 0x1;
                
                _cpu.Registers.SetRegisterValue(Register8BitNames.A, newA);
            }, "RRA", 4, 1);

            public Operation XOR_8(Register8BitNames parameter) => new Operation(() =>
            {
                Console.WriteLine($"XOR {parameter.ToString()}");

                byte registerA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);
                byte parameterRegister = _cpu.Registers.GetRegisterValue(parameter);

                byte result = (byte)(registerA ^ parameterRegister);

                _cpu.Registers.ZZeroFlag = result == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = false;

                _cpu.Registers.SetRegisterValue(Register8BitNames.A, result);
                
            }, $"XOR {parameter.ToString()}", 4, 1);           

            public Operation JP_nn() => new Operation(() =>
            {
                ushort nextPC = (ushort)(_cpu.Registers.GetRegisterValue(Register16BitNames.PC) + 0x1);
                
                ushort addressLsb = _cpu.Memory[nextPC];
                ushort addressMsb = _cpu.Memory[(ushort)(nextPC + 0x1)];

                ushort address = (ushort)((ushort)(addressMsb << 8) | addressLsb);

                Console.WriteLine($"JP 0x{address.ToString("X4")}");

                _cpu.Registers.SetRegisterValue(Register16BitNames.PC, address);
            }, $"JP nn", 12, null);

            public Operation CP(Register8BitNames register) => new Operation(() =>
            {
                Console.WriteLine($"CP {register.ToString()}");

                byte parameter = _cpu.Registers.GetRegisterValue(register);
                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);

                bool currentABit3 = (byte)(((byte)(currentA >> 3)) & 0b_0000_0001) == 0b_1;
                bool parameterBit3 = (byte)(((byte)(parameter >> 3)) & 0b_0000_0001)  == 0b_1;

                _cpu.Registers.ZZeroFlag = currentA == parameter;
                _cpu.Registers.NSubtractFlag = true;
                _cpu.Registers.HHalfCarryFlag = !currentABit3 && parameterBit3;
                _cpu.Registers.CCarryFlag = currentA < parameter;
            }, $"CP {register.ToString()}", 4, 1);

            public Operation ADD_16(Register16BitNames register) => new Operation(() =>
            {
                Console.WriteLine($"ADD HL, {register.ToString()}");

                ushort currentHL = _cpu.Registers.GetRegisterValue(Register16BitNames.HL);
                ushort operand = _cpu.Registers.GetRegisterValue(register);

                ushort result = (ushort)(currentHL + operand);

                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = (currentHL + operand) > 0xFFF;
                _cpu.Registers.CCarryFlag = (currentHL + operand) > ushort.MaxValue;

                _cpu.Registers.SetRegisterValue(Register16BitNames.HL, result);
            }, $"ADD HL, {register.ToString()}", 8, 1);

            public Operation RLCA() => new Operation(() =>
            {
                Console.WriteLine("RLCA");

                byte currentA = _cpu.Registers.GetRegisterValue(Register8BitNames.A);

                byte newLsb = (byte)(currentA >> 7);

                byte shifted = (byte)((byte)(currentA << 1) | newLsb);

                _cpu.Registers.ZZeroFlag = shifted == 0;
                _cpu.Registers.NSubtractFlag = false;
                _cpu.Registers.HHalfCarryFlag = false;
                _cpu.Registers.CCarryFlag = newLsb == 0x1;
            }, $"RLCA", 4, 1);
        }
    }
}